using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace _365ThreeSixtyAPI.Factories
{


    public class fuzzyMatch
    {
        public double FuzzyPercent(string String1, string String2, int Algorithm = 3, bool Normalised = false)
        {
            //normalise strings
            if(Normalised == false)
            {
                String1 = String1.ToLower();
                String2 = String2.ToLower();             
            }

            //give 100% if strings match exactly
            if (String1 == String2)
            {
                return 1;
            }

            //set parameters
            int intLen1 = String1.Length;
            int intLen2 = String2.Length;

            //give 0% if string length <2
            if (intLen1 < 2 || intLen2<2)
            {
                return 0;
            }

            //initilaise totalal possible score
            int intTotScore = 0;
            //initilise current score
            int intScore = 0;

            //if algorythm = 1 or 3 then search for single characters
            if ((Algorithm & 1) != 0)
            {
                if (intLen1 > intLen2)
                {
                    FuzzyAlg1(String1, String2, ref intScore, ref intTotScore);
                }
                else
                {
                    FuzzyAlg1(String2, String1, ref intScore, ref intTotScore);
                }
                
            }
            //if algorymn = 2 then search for pairs etc
            if((Algorithm & 2) != 0)
                if (intLen1 > intLen2)
                {
                    FuzzyAlg2(String1, String2, ref intScore, ref intTotScore);
                }
                else
                {
                    FuzzyAlg2(String2, String1, ref intScore, ref intTotScore);
                }
            return intScore / intTotScore;
        }

        private void FuzzyAlg2(string string1, string string2, ref int intScore, ref int intTotScore)
        {
            int intLen1 = string1.Length;
            for (int intCurLen = 2; intCurLen < intLen1; intCurLen++)
            {
                string strWork = string2;
                int intTo = intLen1 - intCurLen + 1;
                intTotScore = intTotScore + (int)(intLen1 / intCurLen);
                for(int i = 1; i <= intTo; i += intCurLen)
                {
                    int intPos = strWork.IndexOf(string1.Substring(i-1, intCurLen));
                    if (intPos > 0)
                    {
                        //strWork.Substring(i, intPos) = intCurLen.ToString;
                        strWork.Remove(i-1, intPos).Insert(i-1, intCurLen.ToString());
                        intScore++;
                    }
                }
            }
        }

        private void FuzzyAlg1(string string1, string string2,ref int intScore, ref int intTotScore)
                {
                    int intLen1 = string1.Length;
                    intTotScore = intTotScore + intLen1;
                    int intPos = 0;
                    for (int i = 1; i < intLen1; i++)
                    {
                        int intStartPos = intPos + 1;
                        intPos = string2.IndexOf(string1.Substring(i-1, 1), intStartPos-1);
                        if (intPos > 0)
                        {
                            if (intPos > intStartPos + 3)
                            {
                                intPos = intStartPos;
                            }
                            else
                            {
                                intScore++;
                            }
                        }
                        else
                        {
                            intPos = intStartPos-1;
                        }
                    }
                }

            }
        }
     
