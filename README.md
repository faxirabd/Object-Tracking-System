# Object-Tracking-System
The Windows application utilizes a webcam to identify specific geometric shapes like circles, lines, rectangles etc. It employs object recognition techniques using the OpenCV library (Emgu wrapper for C#.NET). Additionally, the application incorporates servo motors to track the detected object's movements. The webcam adjusts its position to match the object's motion.

The project consists of two available source codes:
1.	A C#.NET project that includes the object recognition functionality using OpenCV.
2.	A project in C-language designed for the ATmel Studio IDE, responsible for controlling the pan-tilt camera using the ATmega microcontroller.
   
To establish communication between the C#.NET application and the microcontroller, the tracked object's position is transmitted over the serial port. Therfore it is important to connect the Windows PC to the microcontroller board using a serial port cable.

As a future development, the project has the potential to be adapted for face tracking. For instance, the camera could record a lecture and automatically focus on the lecturer as he moves in the class.

![image](https://github.com/faxirabd/Object-Tracking-System/assets/115953037/f1b34434-2d70-4a55-8c00-af7870d1f3fe)

![image](https://github.com/faxirabd/Object-Tracking-System/assets/115953037/3df3796c-704a-482d-ac1f-cffae92ada69)

![image](https://github.com/faxirabd/Object-Tracking-System/assets/115953037/734d2c5c-a75b-4373-b336-c1ddb87e9d70)
