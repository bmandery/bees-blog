using System;

namespace WorkingWithArrays
{
    /*
     * Date: 2-8-2018
     * Author: bmandery
     * Description: Small program that will ask a user to create an array with dimensions
     * from 1 to 3. Then ask for the number of elements
     * User then has the choice to fill those values, if the values are filled
     * it will display them back to the user
     * ***************************************************************************
     * This isn't the most ideal way to do this, but from what we have learnd up
     * to this point, this is how it's done. Remember, there isn't just
     * 1 way to solve a problem when it comes to programming, just because
     * I did it this way, doesn't mean it's the only way.
     */
    class Program
    {

        static void Main(string[] args)
        {
            Boolean blnKeepLooping = true;

            Console.WriteLine("Welcome to the Array Creator.");
            Console.WriteLine("How many dimensions would you like in your array?");
            Console.Write(">>");

            int intArrayDimension = 0;
            int intArrayElements = 0;

            //Ask for array dimension
            while (blnKeepLooping)
            {
                string strArrayDimensionInput = "";
                strArrayDimensionInput = Console.ReadLine();

                if (Int32.TryParse(strArrayDimensionInput, out intArrayDimension))
                {
                    //We haven't go to logical operators yet
                    //the && says AND.. That line reads
                    //if this is not 0 and it is less than 4
                    //so 1 2 or 3
                    if (intArrayDimension != 0 && intArrayDimension < 4)
                    {
                        blnKeepLooping = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number");
                        Console.Write(">>");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number");
                    Console.Write(">>");
                }
            }

            //Ask for array Elements
            blnKeepLooping = true;
            Console.Clear();
            Console.WriteLine("How many elements would like in the dimension(s)");
            Console.Write(">>");

            while (blnKeepLooping)
            {
                string strArrayElementInput = "";
                strArrayElementInput = Console.ReadLine();

                //This is new it's ok if you don't understand it right now
                //since we havn't gotten to error catching yet.
                if (Int32.TryParse(strArrayElementInput, out intArrayElements))
                {
                    if (intArrayElements != 0)
                    {
                        blnKeepLooping = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number");
                        Console.Write(">>");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number");
                    Console.Write(">>");
                }
            }

            //As you probably have found out, declaring the array dimension at runtime isn't something you can do
            //Or at least I am not aware of a way to do it with out making the array variable local to the if statement
            //If you have discovered away to do this, please share in the comments below.
            string[] arrySingle;
            string[,] arry2D;
            string[,,] arry3D;


            //Single Dimension Array
            if(intArrayDimension == 1)
            {
                arrySingle = new string[intArrayElements];
                Console.Clear();
                Console.WriteLine("Would you like to fill the elements with values?");
                string strAnswer = Console.ReadLine();
                if(strAnswer.ToLower() =="y")
                {
                    //For loop to fill values
                    for(int x=0; x<intArrayElements; x++)
                    {
                        Console.WriteLine("Value for element " + (x+1));
                        Console.Write(">>");
                        arrySingle.SetValue(Console.ReadLine(), x);
                    }

                    Console.Clear();
                    Console.WriteLine("Values in your array");
                    //Display Values
                    for (int x = 0; x < intArrayElements; x++)
                    {
                        Console.WriteLine("Element " + (x + 1) + " " + arrySingle.GetValue(x));
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Press anykey to exit");
                }
            }

            //2 Dimensional Array
            if (intArrayDimension == 2)
            {
                arry2D = (new string[intArrayElements, intArrayElements]);
                Console.Clear();
                Console.WriteLine("Would you like to fill the elements with values?");
                string strAnswer = Console.ReadLine();
                if (strAnswer.ToLower() == "y")
                {
                    //For loop to fill values
                    //Two for loop, 1 for each dimension
                    for(int x0 = 0; x0<intArrayElements; x0++)
                    {
                        for(int x1 = 0; x1<intArrayElements; x1++)
                        {
                            Console.WriteLine("Value for element " + (x0 + 1) + ", " + (x1 + 1));
                            Console.Write(">>");
                            arry2D.SetValue(Console.ReadLine(), x0, x1);
                        }
                    }

                    //Display values
                    Console.Clear();
                    Console.WriteLine("2D Array values");
                    for (int x0 = 0; x0 < intArrayElements; x0++)
                    {
                        for (int x1 = 0; x1 < intArrayElements; x1++)
                        {
                            Console.WriteLine("Value at " + (x0 + 1) + ", " + (x1 + 1) + ": " + arry2D.GetValue(x0, x1));
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Press anykey to exit");
                }
            }


            //3D array
            if (intArrayDimension == 3)
            {
                arry3D = new string[intArrayElements, intArrayElements, intArrayElements];
                Console.Clear();
                Console.WriteLine("Would you like to fill the elements with values?");
                string strAnswer = Console.ReadLine();
                if (strAnswer.ToLower() == "y")
                {
                    //For loop to fill values
                    
                    //1st Dimension
                    for (int x0 = 0; x0 < intArrayElements; x0++)
                    {
                        //2nd dimension
                        for (int x1 = 0; x1 < intArrayElements; x1++)
                        {
                            //3rd dimension
                            for (int x2 = 0; x2 < intArrayElements; x2++)
                            {
                                Console.WriteLine("Value for element " + (x0 + 1) + ", " + (x1 + 1) + ", " + (x2 + 1));
                                Console.Write(">>");
                                arry3D.SetValue(Console.ReadLine(), new int[] {x0,x1,x2 });
                            }
                        }
                    }

                    //Display
                    for (int x0 = 0; x0 < intArrayElements; x0++)
                    {
                        for (int x1 = 0; x1 < intArrayElements; x1++)
                        {
                            for (int x2 = 0; x2 < intArrayElements; x2++)
                            {
                                Console.WriteLine("Value for element " + (x0) + ", " + (x1) + ", " + (x2) + ": " + arry3D.GetValue(new int[] {x0,x1,x2}));
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Press anykey to exit");
                }
            }


            Console.ReadKey();
        }
    }
}
