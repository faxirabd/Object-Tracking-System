using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using System.IO.Ports;
namespace ObjectTracking_V2
{
    public partial class Form1 : Form
    {
        private Capture _capture = null;
        private bool _captureInProgress;
        double cannyThreshold = 180; //'first Canny threshold, used for both circle detection, and line / triangle / rectangle detection
        double cannyThresholdLinking = 150; ////'second Canny threshold for line / triangle / rectangle detection
        int cminsize = 5;
        int cmaxsize = 40;
        int area = 50;
        int polygn = 6;
        int SmoothGaussian = 3;
        //Object Color min max
        private int MinBlue;
        private int MinGreen;
        private int MinRed;
        private int MaxBlue;
        private int MaxGreen;
        private int MaxRed;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //collect all camera
          


            //---------------------
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += timer_Tick;
            serialPort1.Open();
            //set cam start position
            rollx = Xmiddle;
            rolly = Ymiddle;
            serialPort1.Write(new byte[] { 0x00, (byte)(Xmiddle/2), 0x00, (byte)(Ymiddle/2) }, 0, 4);
            Shape_Selection.SelectedIndex = 0;
            //------------------------- min max Circle
            label8.Visible = false;
            Sharpness_LBL.Visible = false;
            Circleminsize_SLD.Visible = false;
            label9.Visible = false;
            label7.Visible = false;
            Circlemaxsize.Visible = false;
            //---------------- area
            label11.Visible = false;
            areatrackBar.Visible = false;
            label10.Visible = false;
            //---------------- Polygn
            label12.Visible = false;
            label13.Visible = false;
            PolygontrackBar1.Visible = false;
            //-------------color filter
            
            
        }
        //controlling cam servos
           SerialPort serialPort1 = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

        byte servo1 = 123;
        byte servo2 = 123;
        uint rollx = 0, rolly = 0;
        //servos region
        Timer timer = null;
        bool firstround = true;
        uint Xleft = 30, Xright = 480, Xmiddle = 250;
        uint Yup = 350, Ydown = 180, Ymiddle = 260;

        ///////////////////////////////////
        private void ProcessFrame(object sender, EventArgs arg)
        {
            int count = 0;

            //circle the cam to look for any objects
            if (firstround == true)
            {
                CircleCam();
            }
            this.Text = firstround.ToString();
            Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame(); //'get frame from webcam
            if (frame != null)//some time it can't find the cam!!!
            {
                Image<Gray, Byte> grayFrame = frame.Convert<Gray, Byte>();
                Image<Gray, Byte> smallGrayFrame = grayFrame.PyrDown();   	//'perform image smoothing
                Image<Gray, Byte> smoothedGrayFrame = smallGrayFrame.PyrUp();  //Convert the image to grayscale and filter out the noise

                Image<Gray, Byte> imgsmoothed = smoothedGrayFrame;
                imgsmoothed.SmoothGaussian(SmoothGaussian);//'Gaussian pyramid decomposition 'Gaussian smooth, argument is size of filter window
                Image<Gray, Byte> gray = imgsmoothed;
                if (checkBox1.Checked == true) //'if filter on color check box is checked, then filter on color
                {
                    Image<Gray, Byte> framefiltercolor = frame.InRange(new Bgr(MinBlue, MinGreen, MinRed), new Bgr(MaxBlue, MaxGreen, MaxRed));
                    framefiltercolor.PyrDown().PyrUp();//'repeat smoothing process after InRange function call,
                    framefiltercolor.SmoothGaussian(3);//'seems to work out better this way
                    gray = framefiltercolor;
                }

                #region Canny and edge detection

                Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);   //'Canny image used for line, triangle, rectangle,pentagon, and polygon detection	
                LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                1, //Distance resolution in pixel-related units
                Math.PI / 45.0, //Angle resolution measured in radians.
                20, //threshold
                30, //min Line width
                10 //gap between lines
                )[0]; //Get the lines from the first channel



                #endregion
                imagecany.Image = cannyEdges;
                //         if(Shape_Selection.SelectedIndex==0 ||Shape_Selection.SelectedIndex==3)
                #region Find rectangles and Trangles
                List<Triangle2DF> triangleList = new List<Triangle2DF>(); //'declare list of triangles
                List<MCvBox2D> boxList = new List<MCvBox2D>(); //a box is a rotated rectangle
                MemStorage storage = new MemStorage(); //allocate storage for contour approximation
                for (
                   Contour<Point> contours = cannyEdges.FindContours(); 		//'find a sequence (similar to a linked list) of contours using the simple approximation method
                   contours != null;
                   contours = contours.HNext)
                {
                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);

                    if (currentContour.Area > area) //only consider contours with area greater than 250
                    {
                        if (currentContour.Total == 4) //The contour has 4 vertices.
                        {
                            if (currentContour.BoundingRectangle.Width > currentContour.BoundingRectangle.Height)
                            {
                                #region determine if all the angles in the contour are within [80, 100] degree
                                bool isRectangle = true;
                                Point[] pts = currentContour.ToArray(); //	'get contour points
                                LineSegment2D[] edges = PointCollection.PolyLine(pts, true);//'get edges between points

                                for (int i = 0; i < edges.Length; i++)
                                {
                                    double angle = Math.Abs(  //'step through edges
                                       edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                    if (angle < 80 || angle > 100) //'if not about a 90 degree angle between edges
                                    {
                                        isRectangle = false;//'can't possibly be a rectangle
                                        break;
                                    }
                                }
                                #endregion

                                if (isRectangle)//'if a rectangle
                                {
                                    boxList.Add(currentContour.GetMinAreaRect());//'add to list of rectangles

                                }
                            }
                        }
                        else if (currentContour.Total == 3) //The contour has 3 vertices, it is a triangle
                        //if(currentContour.Perimeter>294)
                        {
                            Point[] pts = currentContour.ToArray();
                            //  if(pts[2].Y - pts[0].Y==87)

                            triangleList.Add(new Triangle2DF(
                              pts[0],
                              pts[1],
                              pts[2]
                                  ));
                        }

                    }
                }
                #endregion

                #region circle detection
                double circleAccumulatorThreshold = 100;
                CircleF[] circles = gray.HoughCircles( //'find circles
                    new Gray(cannyThreshold),
                    new Gray(circleAccumulatorThreshold),
                    2.0, //Resolution of the accumulator used to detect centers of the circles
                    20.0, //min distance 
                    cminsize, //min radius
                    cmaxsize //max radius
                    )[0]; //Get the circles from the first channel

                #endregion
                if (Shape_Selection.SelectedIndex == 0)
                {
                    #region draw rectangles
                    label11.Visible = true;
                    areatrackBar.Visible = true;
                    label10.Visible = true;

                    //circle the cam to look for any objects
                    if ((boxList.Count == 0) && (round == true))
                    {
                        CircleCam();                        
                    }
                    foreach (MCvBox2D box in boxList)
                    {
                        firstround = false;
                        if (count > 0)
                            break;
                        //object detected
                        round = false;
                        timer.Start();
                        int x = (int)box.center.X;
                        int y = (int)box.center.Y;
                        //now control servos to put the object into the center of the image for the X axis
                        double errorx = (x - 260);
                        if (errorx > 10)
                        {
                            servo1 += 1;
                        }
                        else if (errorx < -10)
                        {
                            servo1 -= 1;
                        }
                        /******************************************************************/
                        //now control servos to put the object into the center of the image for the Y axis
                        double errory = (y - 185);
                        if (errory > 10)
                        {
                            servo2 -= 1;
                        }
                        else if (errory < -10)
                        {
                            servo2 += 1;
                        }
                        /******************************************************************/
                        //now send the new cam positions
                        serialPort1.Write(new byte[] { 0x00, servo1, 0x00, servo2 }, 0, 4);
                        /******************************************************************/
                        MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.1, 1);
                        frame.Draw("Rectangle", ref f, new Point(x, y), new Bgr(Color.Red)); //for write name object
                        frame.Draw(box, new Bgr(Color.Red), 2);
                        if (PosTextBox1.Text != null)
                        {
                            PosTextBox1.AppendText("Rctangle postion x=" + box.center.X.ToString().PadLeft(4) +
                                               ",y=" + box.center.Y.ToString().PadLeft(4));
                            PosTextBox1.AppendText(Environment.NewLine);
                        }

                        PosTextBox1.ScrollToCaret();
                    }
                    imagetrangle.Image = frame;
                    #endregion
                }
                else if (Shape_Selection.SelectedIndex == 1)
                {
                    #region draw circles
                    label8.Visible = true;
                    Sharpness_LBL.Visible = true;
                    Circleminsize_SLD.Visible = true;
                    label9.Visible = true;
                    label7.Visible = true;
                    Circlemaxsize.Visible = true;
                    //circle the cam to look for any objects
                    if ((circles.Count() == 0) && (round == true))
                    {
                        CircleCam();
                    }
                    foreach (CircleF circle in circles)
                    {
                        if (count > 0)
                            break;
                        //object detected
                        round = false;
                        firstround = false;
                        timer.Start();
                        int x = (int)circle.Center.X;
                        int y = (int)circle.Center.Y;
                        //now control servos to put the object into the center of the image for the X axis
                        double errorx = (x - 260);
                        if (errorx > 10)
                        {
                            servo1 += 1;
                        }
                        else if (errorx < -10)
                        {
                            servo1 -= 1;
                        }
                        /******************************************************************/
                        //now control servos to put the object into the center of the image for the Y axis
                        double errory = (y - 185);
                        if (errory > 10)
                        {
                            servo2 -= 1;
                        }
                        else if (errory < -10)
                        {
                            servo2 += 1;
                        }
                        /******************************************************************/
                        //now send the new cam positions
                        serialPort1.Write(new byte[] { 0x00, servo1, 0x00, servo2 }, 0, 4);
                        /******************************************************************/

                        MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.1, 1);
                        frame.Draw("circle", ref f, new Point(x, y), new Bgr(Color.Azure));//draw circles on circles image
                        frame.Draw(circle, new Bgr(Color.Yellow), 2);
                        if (PosTextBox1.Text != null)
                        {
                            PosTextBox1.AppendText(Environment.NewLine);
                            PosTextBox1.AppendText("Ball postion x=" + circle.Center.X.ToString().PadLeft(4) +
                                              ",y=" + circle.Center.Y.ToString().PadLeft(4) +
                                              ",Radius=" + circle.Radius.ToString("##.00").PadLeft(7));
                        }
                        PosTextBox1.ScrollToCaret();
                    }

                    imagetrangle.Image = frame;

                    #endregion
                }
                else if (Shape_Selection.SelectedIndex == 2)
                {
                    #region draw lines
                    foreach (LineSegment2D line in lines)
                    {
                        frame.Draw(line, new Bgr(Color.Green), 2);

                    }
                    imagetrangle.Image = frame;
                    #endregion
                }
                else if (Shape_Selection.SelectedIndex == 3)
                {
                    #region draw triangles

                    label11.Visible = true;
                    areatrackBar.Visible = true;
                    label10.Visible = true;
                    //circle the cam to look for any objects
                    if ((triangleList.Count == 0) && (round == true))
                    {
                        CircleCam();
                    }
                    foreach (Triangle2DF triangle in triangleList)
                    {
                        if (count > 0)
                            break;
                        //object detected
                        round = false;
                        firstround = false;
                        timer.Start();
                        int x = (int)triangle.Centeroid.X - 20;
                        int y = (int)triangle.Centeroid.Y;
                        //now control servos to put the object into the center of the image for the X axis
                        double errorx = (x - 260);
                        if (errorx > 10)
                        {
                            servo1 += 1;
                        }
                        else if (errorx < -10)
                        {
                            servo1 -= 1;
                        }
                        /******************************************************************/
                        //now control servos to put the object into the center of the image for the Y axis
                        double errory = (y - 185);
                        if (errory > 10)
                        {
                            servo2 -= 1;
                        }
                        else if (errory < -10)
                        {
                            servo2 += 1;
                        }
                        /******************************************************************/
                        //now send the new cam positions
                        serialPort1.Write(new byte[] { 0x00, servo1, 0x00, servo2 }, 0, 4);
                        /******************************************************************/
                        MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.1, 1);
                        frame.Draw("Triangle", ref f, new Point(x, y), new Bgr(Color.Black));

                        frame.Draw(triangle, new Bgr(Color.Red), 2);
                        if (PosTextBox1.Text != null)
                        {
                            PosTextBox1.AppendText("Triangle postion x=" + triangle.Centeroid.X.ToString().PadLeft(4) +
                                               ",y=" + triangle.Centeroid.Y.ToString().PadLeft(4));
                            PosTextBox1.AppendText(Environment.NewLine);
                        }
                        PosTextBox1.ScrollToCaret();
                    }
                    imagetrangle.Image = frame;

                    #endregion
                }
                else if (Shape_Selection.SelectedIndex == 4)
                {
                    #region Detect Pentagon
                    List<Contour<Point>> aaa = new List<Contour<Point>>(); //'declare list of pentagon
                    for (Contour<Point> contours = cannyEdges.FindContours(); contours != null; contours = contours.HNext)
                    {

                        Contour<Point> currentContour = contours.ApproxPoly(10.0, storage);
                        if (currentContour.Total == 5) //The contour has 5 vertices.
                        {
                            #region determine if all the angles in the contour are within [98, 118] degree
                            bool isPentagon = true;
                            Point[] pts = currentContour.ToArray();
                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);
                            #endregion
                            for (int i = 0; i < edges.Length; i++)
                            {
                                double angle = Math.Abs(
                                   edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                if (angle < 50 || angle > 100)
                                {
                                    isPentagon = false;
                                    break;
                                }
                            }
                            if (isPentagon) aaa.Add(currentContour);
                        }

                    }


                    //circle the cam to look for any objects
                    if ((aaa.Count == 0) && (round == true))
                    {
                        CircleCam();
                    }

                    foreach (Contour<Point> pentagon in aaa)
                    {
                        if (count > 0)
                            break;
                        //object detected
                        firstround = false;
                        round = false;
                        timer.Start();

                        int x = (int)pentagon.BoundingRectangle.X;
                        int y = (int)pentagon.BoundingRectangle.Y;
                        //now control servos to put the object into the center of the image for the X axis
                        double errorx = (x - 260);
                        if (errorx > 10)
                        {
                            servo1 += 1;
                        }
                        else if (errorx < -10)
                        {
                            servo1 -= 1;
                        }
                        /******************************************************************/
                        //now control servos to put the object into the center of the image for the Y axis
                        double errory = (y - 185);
                        if (errory > 10)
                        {
                            servo2 -= 1;
                        }
                        else if (errory < -10)
                        {
                            servo2 += 1;
                        }
                        /******************************************************************/
                        //now send the new cam positions
                        serialPort1.Write(new byte[] { 0x00, servo1, 0x00, servo2 }, 0, 4);
                        /******************************************************************/

                        MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.1, 1);
                        frame.Draw("Pentagon", ref f, new Point(x, y), new Bgr(Color.Red));

                        frame.Draw(pentagon, new Bgr(Color.Aqua), 2);
                        if (PosTextBox1.Text != null)
                        {
                            PosTextBox1.AppendText("Pentagon postion x=" + pentagon.BoundingRectangle.X.ToString().PadLeft(4) +
                                                    ",y=" + pentagon.BoundingRectangle.Y.ToString().PadLeft(4));
                            PosTextBox1.AppendText(Environment.NewLine);
                        }
                        PosTextBox1.ScrollToCaret();
                        count++;
                    }

                    imagetrangle.Image = frame;


                    #endregion
                }
                else if (Shape_Selection.SelectedIndex == 5)
                {
                    #region Detect Polygon
                    label12.Visible = true;
                    label13.Visible = true;
                    PolygontrackBar1.Visible = true;
                    List<Contour<Point>> aaa = new List<Contour<Point>>();//'declare list of polygons
                    for (Contour<Point> contours = cannyEdges.FindContours(); contours != null; contours = contours.HNext)
                    {

                        Contour<Point> currentContour = contours.ApproxPoly(10.0, storage);
                        if (currentContour.Total == polygn) //The contour has morethan 5 vertices.//'if 4, or 6 points or other, could be a square or a polygon
                        {
                            #region determine if all the angles in the contour are within [98, 118] degree
                            bool isPolygon = true;
                            Point[] pts = currentContour.ToArray();
                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);
                            #endregion
                            for (int i = 0; i < edges.Length; i++)
                            {
                                double angle = Math.Abs(
                                   edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                if (angle < 50 || angle > 100)
                                {
                                    isPolygon = false;
                                    break;
                                }
                            }
                            if (isPolygon) aaa.Add(currentContour);//'add to list of polygons
                        }
                    }

                    //circle the cam to look for any objects
                    if ((aaa.Count == 0) && (round == true))
                    {
                        CircleCam();
                    }
                    foreach (Contour<Point> Polygon in aaa)
                    {            
                        if (count > 0)
                            break;
                        //object detected
                        firstround = false;
                        round = false;
                        timer.Start();

                        int x = (int)Polygon.BoundingRectangle.X;
                        int y = (int)Polygon.BoundingRectangle.Y;
                        //now control servos to put the object into the center of the image for the X axis
                        double errorx = (x - 260);
                        if (errorx > 10)
                        {
                            servo1 += 1;
                        }
                        else if (errorx < -10)
                        {
                            servo1 -= 1;
                        }
                        /******************************************************************/
                        //now control servos to put the object into the center of the image for the Y axis
                        double errory = (y - 185);
                        if (errory > 10)
                        {
                            servo2 -= 1;
                        }
                        else if (errory < -10)
                        {
                            servo2 += 1;
                        }
                        /******************************************************************/
                        //now send the new cam positions
                        serialPort1.Write(new byte[] { 0x00, servo1, 0x00, servo2 }, 0, 4);
                        /******************************************************************/

                        MCvFont f = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.1, 1);
                        frame.Draw("Polygon", ref f, new Point(x, y), new Bgr(Color.Blue));
                        frame.Draw(Polygon, new Bgr(Color.Brown), 2);
                        if (PosTextBox1.Text != null)
                        {
                            PosTextBox1.AppendText("Polygon postion x=" + Polygon.BoundingRectangle.X.ToString().PadLeft(4) +
                                               ",y=" + Polygon.BoundingRectangle.Y.ToString().PadLeft(4));
                            PosTextBox1.AppendText(Environment.NewLine);
                        }
                        PosTextBox1.ScrollToCaret();
                    }

                    imagetrangle.Image = frame;

                    #endregion
                }
            }
        }

        void CircleCam()
        {
            rollx++;
            servo1 = (byte)(rollx / 2);
            rolly++;
            servo2 = (byte)(rolly / 2);
            serialPort1.Write(new byte[] { 0x00, servo1, 0x00, servo2 }, 0, 4);

            if (rollx == Xright)
                rollx = Xleft;
            if (rolly == Yup)
                rolly = Ydown;
        }
        bool round = false;
        void timer_Tick(object sender, EventArgs e)
        {
            rollx = (uint)servo1 * 2;
            rolly = (uint)servo2 * 2;
            round = true;
            timer.Stop();
        }
        private void ReleaseData()
        {
            if (_capture != null)
                _capture.Dispose();
        }


        private void captureButton_Click(object sender, EventArgs e)
        {
            MinBlue = (int)Convert.ToInt32(Bmin.Text);
            MinGreen = (int)Convert.ToInt32(Gmin.Text);
            MinRed = (int)Convert.ToInt32(Rmin.Text);
            MaxBlue = (int)Convert.ToInt32(Bmax.Text);
            MaxGreen = (int)Convert.ToInt32(Gmax.Text);
            MaxRed = (int)Convert.ToInt32(Rmax.Text);
            if (_capture == null)
            {
                try
                {
                    _capture = new Capture(0);

                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }

            if (_capture != null)
            {
                if (_captureInProgress)
                { //if camera is getting frames then stop the capture and set button Text
                    // "Start" for resuming capture
                    captureButton.Text = "Start!"; //
                    PosTextBox1.Text = null;
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    //if camera is NOT getting frames then start the capture and set button
                    // Text to "Stop" for pausing capture
                    captureButton.Text = "Stop";
                    Application.Idle += ProcessFrame;
                }
                _captureInProgress = !_captureInProgress;
            }
        
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReleaseData();
        }

        private void flipHorizontalButton_Click(object sender, EventArgs e)
        {
            if (_capture != null) _capture.FlipHorizontal = !_capture.FlipHorizontal;
        }

        private void flipVerticalButton_Click(object sender, EventArgs e)
        {
            if (_capture != null) _capture.FlipVertical = !_capture.FlipVertical;
        }

        private void Brigtness_SLD_Scroll(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                _capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_BRIGHTNESS, Brigtness_SLD.Value);
                Brigthness_LBL.Text = Brigtness_SLD.Value.ToString();
            }
        }

        private void Threshold_SLD_Scroll(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                cannyThreshold = Threshold_SLD.Value;
                Contrast_LBL.Text = cannyThreshold.ToString();
            }
        }

        private void Circleminsize_SLD_Scroll(object sender, EventArgs e)
        {
            cmaxsize = Circlemaxsize.Value;
            Circleminsize_SLD.Text = cmaxsize.ToString();
        }

        private void Circlemaxsize_Scroll(object sender, EventArgs e)
        {
            cmaxsize = Circlemaxsize.Value;
            label7.Text = cmaxsize.ToString();
        }

        private void areatrackBar_Scroll(object sender, EventArgs e)
        {
            area = areatrackBar.Value;
            label10.Text = area.ToString();
        }

        private void PolygontrackBar1_Scroll(object sender, EventArgs e)
        {
            polygn = PolygontrackBar1.Value;
            label12.Text = polygn.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  serialPort1.Write(new byte[] { 0x00, 123, 0x00, 123}, 0, 4);
            serialPort1.Close();

        }

        private void Bmin_TextChanged(object sender, EventArgs e)
        {

            if (Bmin.Text == "") Bmin.Text = "0";
            MinBlue = (int)Convert.ToInt32(Bmin.Text);
            MinGreen = (int)Convert.ToInt32(Gmin.Text);
            MinRed = (int)Convert.ToInt32(Rmin.Text);
            MaxBlue = (int)Convert.ToInt32(Bmax.Text);
            MaxGreen = (int)Convert.ToInt32(Gmax.Text);
            MaxRed = (int)Convert.ToInt32(Rmax.Text);
        }

        private void Gmin_TextChanged(object sender, EventArgs e)
        {
            if (Gmin.Text == "") Gmin.Text = "0";
            MinBlue = (int)Convert.ToInt32(Bmin.Text);
            MinGreen = (int)Convert.ToInt32(Gmin.Text);
            MinRed = (int)Convert.ToInt32(Rmin.Text);
            MaxBlue = (int)Convert.ToInt32(Bmax.Text);
            MaxGreen = (int)Convert.ToInt32(Gmax.Text);
            MaxRed = (int)Convert.ToInt32(Rmax.Text);
        }

        private void Rmin_TextChanged(object sender, EventArgs e)
        {
            if (Rmin.Text == "") Rmin.Text = "0";
            MinBlue = (int)Convert.ToInt32(Bmin.Text);
            MinGreen = (int)Convert.ToInt32(Gmin.Text);
            MinRed = (int)Convert.ToInt32(Rmin.Text);
            MaxBlue = (int)Convert.ToInt32(Bmax.Text);
            MaxGreen = (int)Convert.ToInt32(Gmax.Text);
            MaxRed = (int)Convert.ToInt32(Rmax.Text);
        }

        private void Bmax_TextChanged(object sender, EventArgs e)
        {

            if (Bmax.Text == "") Bmax.Text = "1";
            MinBlue = (int)Convert.ToInt32(Bmin.Text);
            MinGreen = (int)Convert.ToInt32(Gmin.Text);
            MinRed = (int)Convert.ToInt32(Rmin.Text);
            MaxBlue = (int)Convert.ToInt32(Bmax.Text);
            MaxGreen = (int)Convert.ToInt32(Gmax.Text);
            MaxRed = (int)Convert.ToInt32(Rmax.Text);
        }

        private void Gmax_TextChanged(object sender, EventArgs e)
        {
            if (Gmax.Text == "") Gmax.Text = "1";
            MinBlue = (int)Convert.ToInt32(Bmin.Text);
            MinGreen = (int)Convert.ToInt32(Gmin.Text);
            MinRed = (int)Convert.ToInt32(Rmin.Text);
            MaxBlue = (int)Convert.ToInt32(Bmax.Text);
            MaxGreen = (int)Convert.ToInt32(Gmax.Text);
            MaxRed = (int)Convert.ToInt32(Rmax.Text);
        }

        private void Rmax_TextChanged(object sender, EventArgs e)
        {

            if (Rmax.Text == "") Rmax.Text = "1";
            MinBlue = (int)Convert.ToInt32(Bmin.Text);
            MinGreen = (int)Convert.ToInt32(Gmin.Text);
            MinRed = (int)Convert.ToInt32(Rmin.Text);
            MaxBlue = (int)Convert.ToInt32(Bmax.Text);
            MaxGreen = (int)Convert.ToInt32(Gmax.Text);
            MaxRed = (int)Convert.ToInt32(Rmax.Text);

        }

        private void Reset_Cam_Settings_Click(object sender, EventArgs e)
        {
            serialPort1.Write(new byte[] { 0x00, 123, 0x00, 123 }, 0, 4);
        }
    }
}
