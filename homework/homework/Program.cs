using System;
using System.Collections.Generic;

namespace homework
{
    class Program
    {
        class InputValue
    {
        public string Intruction, Data; 
    }
        class CPU
    {
        public string CpuIntruction;
        public string[] CpuData = new string[3];
    }
        /////////////////////////////////////////////
        static void Main(string[] args)
        {
            List<InputValue> inputvalue = new List<InputValue>();


            while (true)
            {

                string InputIntruction = Console.ReadLine(); //รับค่ามาใส่ตัวแปรInputIntruction
                if (InputIntruction == "?")
                {
                    calculate(inputvalue);
                    break; //หยุดloop
                }
                else
                {
                    inputvalue.Add(InputIntructionAndDaTa(InputIntruction)); //loopเรื่อยๆ , ส่งค่าที่ได้รับมาไปที่ฟังก์ชั่น InputIntructionAndDaTa
                }
            }

        }
        ////////////////////////////////////////////
        static InputValue InputIntructionAndDaTa(string value)
        {
            string[] words = value.Split(' '); //number 
            string Intruction = words[0]; //split to intruction
            string Data = words[1];//split to Data
            InputValue inputValue = new InputValue(); //use calss 
            inputValue.Intruction = Intruction; //keep data
            inputValue.Data = Data; //keep data
            return inputValue; //Return data 
        }
        ////////////////////////////////////////////
        static void calculate(List<InputValue> inputvalue, int count = 0)
        {
            count++;
            List<InputValue> waitingdata = new List<InputValue>();
            CPU[] cpu = new CPU[4]; //ที่เก็บค่า 
            for (int a = 0; a < cpu.Length; a++)
            {
                cpu[a] = new CPU();
            }
            for (int i = 0; i < inputvalue.Count; i++)
            {
                string ins = inputvalue[i].Intruction;
                for (int j = 0; j < cpu.Length; j++)
                {
                    if (cpu[j].CpuIntruction == null || cpu[j].CpuIntruction == ins)
                    {
                        cpu[j].CpuIntruction = ins;
                        for (int b = 0; b < cpu[j].CpuData.Length; b++)
                        {
                            if (cpu[j].CpuData[b] == null || cpu[j].CpuData[b] == inputvalue[i].Data)
                            {
                                cpu[j].CpuData[b] = inputvalue[i].Data;
                                break;
                            }
                            else if (b == cpu[j].CpuData.Length - 1)
                            {
                                waitingdata.Add(inputvalue[i]);
                                break;
                            }
                        }
                        break;
                    }
                    else if (j == cpu.Length - 1)
                    {
                        waitingdata.Add(inputvalue[i]);
                    }

                }
            }
            if (waitingdata.Count > 0)
            {
                calculate(waitingdata, count);
            }
            else
            {
                Console.WriteLine("CPU cycles needed: " + count);
            }
        }
    }
}

