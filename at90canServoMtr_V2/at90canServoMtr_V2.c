#include <avr/io.h>

#include "uart.h"

#define ZeroServoPosition 0x0040
#define ZeroServoPositionL 0x40
#define ZeroServoPositionH 0x00

#define ZeroMotorPosition 0x00AD
#define ZeroMotorPositionL 0xAD
#define ZeroMotorPositionH 0x00

void pwm_initTimer1();
void pwm_initTimer3();

int main()
{
	DDRA=0xff;//only for test purposes, This is 8 LEDs
	uartinit0(9600);
	pwm_initTimer1();
	pwm_initTimer3();

	//this byte indicates Servo1 or Motor left Control and Motor left Direction
	unsigned char byte1= 0;
	unsigned char byte2= 0;//value of Servo 1 or Motor left
	//this byte indicates Servo2 or Motor right Control and Motor right Direction
	unsigned char byte3= 0;
	unsigned char byte4= 0;//value of Servo 2 or Motor right


	while(1)
	{
	    byte1=getChar0();
		byte2=getChar0();
		byte3=getChar0();
		byte4=getChar0();
		PORTA=byte2;

		if(byte1 ==0)
		{
			//Servo1 Control
			//add new value to the zero position of the Servo 1
			OCR1A	= ZeroServoPosition+byte2;
		}

		if(byte3==0)
		{
			//Servo2 Control
			//add new value to the zero position of the Servo 2
			OCR1B	= ZeroServoPosition+byte4;
		}
	
	}
return 0;
}


void pwm_initTimer3()
{
	DDRE |= ( 1 << PE3 );	//E3 = OC3A Timer3 pwm cahnnel A
	DDRE |= ( 1 << PE4 );	//E4 = OC3B Timer3 pwm cahnnel B

	TCCR3A = 0b10101010;	//Channel A, B PWM mod ?

	TCCR3B = 0b00011011;  	//Perescaller 64

	//zero position of the Servo 1
	OCR3AH	= ZeroMotorPositionH;
	OCR3AL	= ZeroMotorPositionL;
	//zero position of the Servo 2
	OCR3BH	= ZeroMotorPositionH;
	OCR3BL	= ZeroMotorPositionL;

	//just to generate the time period
	ICR3=2550;//1175;//0x0398;
}

void pwm_initTimer1()
{
	DDRB |= ( 1 << PB5 );	//B5 = OC1A Timer1 pwm cahnnel A
	DDRB |= ( 1 << PB6 );	//B6 = OC1B Timer1 pwm cahnnel B

	TCCR1A = 0b10101010;	//Channel A, B PWM mod ?

	TCCR1B = 0b00011011;  	//Perescaller 64

	//zero position of the Servo 1
	OCR1AH	= ZeroServoPositionH;
	OCR1AL	= ZeroServoPositionL;
	//zero position of the Servo 2
	OCR1BH	= ZeroServoPositionH;
	OCR1BL	= ZeroServoPositionL;

	//just to generate the time period
	ICR1=2550;//1175;//0x0398;
}
