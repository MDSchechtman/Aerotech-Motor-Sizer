using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Record
{
    public class Record
    {
        private int ItemsPerLine = 17;
        private double RecordAxisOneMaxForce;
        private double RecordAxisOneRMSForce;
        private double RecordAxisOneMaxCurrent;
        private double RecordAxisOneRMSCurrent;
        private double RecordAxisOneTempRise;
        private double RecordAxisTwoMaxForce;
        private double RecordAxisTwoRMSForce;
        private double RecordAxisTwoMaxCurrent;
        private double RecordAxisTwoRMSCurrent;
        private double RecordAxisTwoTempRise;
        private double RecordAxisThreeMaxForce;
        private double RecordAxisThreeRMSForce;
        private double RecordAxisThreeMaxCurrent;
        private double RecordAxisThreeRMSCurrent;
        private double RecordAxisThreeTempRise;
        private List<double> RecordAxisOneTime;
        private List<double> RecordAxisOnePosition;
        private List<double> RecordAxisOneVelocity;
        private List<double> RecordAxisOneAcceleration;
        private List<double> RecordAxisTwoTime;
        private List<double> RecordAxisTwoPosition;
        private List<double> RecordAxisTwoVelocity;
        private List<double> RecordAxisTwoAcceleration;
        private List<double> RecordAxisThreeTime;
        private List<double> RecordAxisThreePosition;
        private List<double> RecordAxisThreeVelocity;
        private List<double> RecordAxisThreeAcceleration;

        public Record()
        {
            RecordAxisOneTime = new List<double>();
            RecordAxisOnePosition = new List<double>();
            RecordAxisOneVelocity = new List<double>();
            RecordAxisOneAcceleration = new List<double>();
            RecordAxisTwoTime = new List<double>();
            RecordAxisTwoPosition = new List<double>();
            RecordAxisTwoVelocity = new List<double>();
            RecordAxisTwoAcceleration = new List<double>();
            RecordAxisThreeTime = new List<double>();
            RecordAxisThreePosition = new List<double>();
            RecordAxisThreeVelocity = new List<double>();
            RecordAxisThreeAcceleration = new List<double>();
        }

        public void AddState(double axisOneTime, double axisOnePosition, double axisOneVelocity, double axisOneAcceleration, double axisTwoTime, double axisTwoPosition, double axisTwoVelocity, double axisTwoAcceleration, double axisThreeTime, double axisThreePosition, double axisThreeVelocity, double axisThreeAcceleration)
        {
            this.RecordAxisOneTime.Add(axisOneTime);
            this.RecordAxisOnePosition.Add(axisOnePosition);
            this.RecordAxisOneVelocity.Add(axisOneVelocity);
            this.RecordAxisOneAcceleration.Add(axisOneAcceleration);
            this.RecordAxisTwoTime.Add(axisTwoTime);
            this.RecordAxisTwoPosition.Add(axisTwoPosition);
            this.RecordAxisTwoVelocity.Add(axisTwoVelocity);
            this.RecordAxisTwoAcceleration.Add(axisTwoAcceleration);
            this.RecordAxisThreeTime.Add(axisThreeTime);
            this.RecordAxisThreePosition.Add(axisThreePosition);
            this.RecordAxisThreeVelocity.Add(axisThreeVelocity);
            this.RecordAxisThreeAcceleration.Add(axisThreeAcceleration);
        }

        public void WriteToFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Record.txt"))
            {
                file.WriteLine("Max Force of Axis One:          "+RecordAxisOneMaxForce);
                file.WriteLine("RMS Force of Axis One:          "+RecordAxisOneRMSForce);
                file.WriteLine("Max Current of Axis One:        "+RecordAxisOneMaxCurrent);
                file.WriteLine("RMS Current of Axis One:        "+RecordAxisOneRMSCurrent);
                file.WriteLine("Temperature Rise of Axis One:   "+RecordAxisOneTempRise);
                file.WriteLine("Max Force of Axis Two:          "+RecordAxisTwoMaxForce);
                file.WriteLine("RMS Force of Axis Two:          "+RecordAxisTwoRMSForce);
                file.WriteLine("Max Current of Axis Two:        "+RecordAxisTwoMaxCurrent);
                file.WriteLine("RMS Current of Axis Two:        "+RecordAxisTwoRMSCurrent);
                file.WriteLine("Temperature Rise of Axis Two:   "+RecordAxisTwoTempRise);
                file.WriteLine("Max Force of Axis Three:        "+RecordAxisThreeMaxForce);
                file.WriteLine("RMS Force of Axis Three:        "+RecordAxisThreeRMSForce);
                file.WriteLine("Max Current of Axis Three:      "+RecordAxisThreeMaxCurrent);
                file.WriteLine("RMS Current of Axis Three:      "+RecordAxisThreeRMSCurrent);
                file.WriteLine("Temperature Rise of Axis Three: " + RecordAxisThreeTempRise);

                
                file.WriteLine("\r\nAxis One Time Array:");
                string ToWrite = "";
                int ThisIsACounter=0;
                for (int i = 0; i < RecordAxisOneTime.Count; i++)
                {
                    ToWrite+=RecordAxisOneTime[i]+", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite="";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite="";

                file.WriteLine("\r\nAxis One Position Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisOnePosition.Count; i++)
                {
                    ToWrite += RecordAxisOnePosition[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis One Velocity Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisOneVelocity.Count; i++)
                {
                    ToWrite += RecordAxisOneVelocity[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis One Acceleration Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisOneAcceleration.Count; i++)
                {
                    ToWrite += RecordAxisOneAcceleration[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis Two Time Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisTwoTime.Count; i++)
                {
                    ToWrite += RecordAxisTwoTime[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis Two Position Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisTwoPosition.Count; i++)
                {
                    ToWrite += RecordAxisTwoPosition[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis Two Velocity Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisTwoVelocity.Count; i++)
                {
                    ToWrite += RecordAxisTwoVelocity[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis Two Acceleration Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisTwoAcceleration.Count; i++)
                {
                    ToWrite += RecordAxisTwoAcceleration[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis Three Time Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisThreeTime.Count; i++)
                {
                    ToWrite += RecordAxisThreeTime[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis Three Position Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisThreePosition.Count; i++)
                {
                    ToWrite += RecordAxisThreePosition[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis Three Velocity Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisThreeVelocity.Count; i++)
                {
                    ToWrite += RecordAxisThreeVelocity[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

                file.WriteLine("\r\nAxis Three Acceleration Array:");
                ToWrite = "";
                ThisIsACounter = 0;
                for (int i = 0; i < RecordAxisThreeAcceleration.Count; i++)
                {
                    ToWrite += RecordAxisThreeAcceleration[i] + ", ";
                    ThisIsACounter++;
                    if (ThisIsACounter == ItemsPerLine)
                    {
                        file.WriteLine(ToWrite);
                        ToWrite = "";
                        ThisIsACounter = 0;
                    }
                }
                file.WriteLine(ToWrite);
                ToWrite = "";

            }
        }

        //get and set the max force of axis one
        public double AxisOneMaxForce
        {
            get
            {
                return RecordAxisOneMaxForce;
            }
            set
            {
                RecordAxisOneMaxForce = value;
            }
        }

        //get and set the RMS force of axis one
        public double AxisOneRMSForce
        {
            get
            {
                return RecordAxisOneRMSForce;
            }
            set
            {
                RecordAxisOneRMSForce = value;
            }
        }

        //get and set the max current of axis one
        public double AxisOneMaxCurrent
        {
            get
            {
                return RecordAxisOneMaxCurrent;
            }
            set
            {
                RecordAxisOneMaxCurrent = value;
            }
        }

        //get and set the RMS current of axis one
        public double AxisOneRMSCurrent
        {
            get
            {
                return RecordAxisOneRMSCurrent;
            }
            set
            {
                RecordAxisOneRMSCurrent = value;
            }
        }

        //get and set the temperature rise of axis one
        public double AxisOneTempRise
        {
            get
            {
                return RecordAxisOneTempRise;
            }
            set
            {
                RecordAxisOneTempRise = value;
            }
        }

        //get and set the max force of axis two
        public double AxisTwoMaxForce
        {
            get
            {
                return RecordAxisTwoMaxForce;
            }
            set
            {
                RecordAxisTwoMaxForce = value;
            }
        }

        //get and set the RMS force of axis two
        public double AxisTwoRMSForce
        {
            get
            {
                return RecordAxisTwoRMSForce;
            }
            set
            {
                RecordAxisTwoRMSForce = value;
            }
        }

        //get and set the max current of axis two
        public double AxisTwoMaxCurrent
        {
            get
            {
                return RecordAxisTwoMaxCurrent;
            }
            set
            {
                RecordAxisTwoMaxCurrent = value;
            }
        }

        //get and set the RMS current of axis two
        public double AxisTwoRMSCurrent
        {
            get
            {
                return RecordAxisTwoRMSCurrent;
            }
            set
            {
                RecordAxisTwoRMSCurrent = value;
            }
        }

        //get and set the temperature rise of axis two
        public double AxisTwoTempRise
        {
            get
            {
                return RecordAxisTwoTempRise;
            }
            set
            {
                RecordAxisTwoTempRise = value;
            }
        }

        //get and set the max force of axis three
        public double AxisThreeMaxForce
        {
            get
            {
                return RecordAxisThreeMaxForce;
            }
            set
            {
                RecordAxisThreeMaxForce = value;
            }
        }

        //get and set the RMS force of axis three
        public double AxisThreeRMSForce
        {
            get
            {
                return RecordAxisThreeRMSForce;
            }
            set
            {
                RecordAxisThreeRMSForce = value;
            }
        }

        //get and set the max current of axis three
        public double AxisThreeMaxCurrent
        {
            get
            {
                return RecordAxisThreeMaxCurrent;
            }
            set
            {
                RecordAxisThreeMaxCurrent = value;
            }
        }

        //get and set the RMS current of axis three
        public double AxisThreeRMSCurrent
        {
            get
            {
                return RecordAxisThreeRMSCurrent;
            }
            set
            {
                RecordAxisThreeRMSCurrent = value;
            }
        }

        //get and set the temperature rise of axis three
        public double AxisThreeTempRise
        {
            get
            {
                return RecordAxisThreeTempRise;
            }
            set
            {
                RecordAxisThreeTempRise = value;
            }
        }

        //get and set the axis one time array
        public List<double> AxisOneTime
        {
            get
            {
                return RecordAxisOneTime;
            }
            set
            {
                RecordAxisOneTime = value;
            }
        }

        //get and set the axis one position array
        public List<double> AxisOnePosition
        {
            get
            {
                return RecordAxisOnePosition;
            }
            set
            {
                RecordAxisOnePosition = value;
            }
        }

        //get and set the axis one velocity array
        public List<double> AxisOneVelocity
        {
            get
            {
                return RecordAxisOneVelocity;
            }
            set
            {
                RecordAxisOneVelocity = value;
            }
        }

        //get and set the axis one acceleration array
        public List<double> AxisOneAcceleration
        {
            get
            {
                return RecordAxisOneAcceleration;
            }
            set
            {
                RecordAxisOneAcceleration = value;
            }
        }

        //get and set the axis two time array
        public List<double> AxisTwoTime
        {
            get
            {
                return RecordAxisTwoTime;
            }
            set
            {
                RecordAxisTwoTime = value;
            }
        }

        //get and set the axis two position array
        public List<double> AxisOTwoPosition
        {
            get
            {
                return RecordAxisTwoPosition;
            }
            set
            {
                RecordAxisTwoPosition = value;
            }
        }

        //get and set the axis two velocity array
        public List<double> AxisTwoVelocity
        {
            get
            {
                return RecordAxisTwoVelocity;
            }
            set
            {
                RecordAxisTwoVelocity = value;
            }
        }

        //get and set the axis two acceleration array
        public List<double> AxisTwoAcceleration
        {
            get
            {
                return RecordAxisTwoAcceleration;
            }
            set
            {
                RecordAxisTwoAcceleration = value;
            }
        }

        //get and set the axis three time array
        public List<double> AxisThreeTime
        {
            get
            {
                return RecordAxisThreeTime;
            }
            set
            {
                RecordAxisThreeTime = value;
            }
        }

        //get and set the axis three position array
        public List<double> AxisThreePosition
        {
            get
            {
                return RecordAxisThreePosition;
            }
            set
            {
                RecordAxisThreePosition = value;
            }
        }

        //get and set the axis three velocity array
        public List<double> AxisThreeVelocity
        {
            get
            {
                return RecordAxisThreeVelocity;
            }
            set
            {
                RecordAxisThreeVelocity = value;
            }
        }

        //get and set the axis three acceleration array
        public List<double> AxisThreeAcceleration
        {
            get
            {
                return RecordAxisThreeAcceleration;
            }
            set
            {
                RecordAxisThreeAcceleration = value;
            }
        }

    }
}