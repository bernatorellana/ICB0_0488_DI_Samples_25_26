using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTestingTeatre.Model
{
    public class TheIncredibleMachine
    {

        private int stage = 0;

        public int crunch(int[] data)
        {
            int i = 0;
            int stage0count = 0;
            int[] stage1stats = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int stage2magicnumber = 13;
            while (stage < 3 && i < data.Length)
            {
                if (data[i] > 9 || data[i] < 0) { i++; continue; }
                switch (stage)
                {
                    case 0:
                        if (i > 0 && data[i] == data[i - 1])
                        {
                            stage0count++;
                        }
                        else
                        {
                            stage0count = 0;
                        }
                        if (stage0count > 4)
                        {
                            stage++;
                        }
                        break;
                    case 1:
                        stage1stats[data[i]]++;
                        int numGreaterThanThree = 0;
                        for (int k = 0; k < stage1stats.Length; k++)
                        {
                            if (stage1stats[k] > 3) numGreaterThanThree++;
                        }
                        if (numGreaterThanThree > 2)
                        {
                            stage++;
                        }
                        break;
                    case 2:
                        i += data[i];
                        stage2magicnumber -= data[i];
                        if (stage2magicnumber == 0)
                        {
                            stage++;
                        }
                        break;
                } // end switch
                //
                i++;
            } // end while
            if (stage == 3)
            {
                Console.WriteLine("Awesome dude !");
            }
            return stage;
        }
    }
}
