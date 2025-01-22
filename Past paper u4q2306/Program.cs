using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

string Address;
string Name;
string phonenumber;

int numberofparcels;
int Height;
int Length;
int Width;
int[] size = new int[6];
int[] Weight = new int[6];
bool [] Signature = new bool[6];
bool [] parceltracking = new bool[6];
int[] price = new int[6];
int finalPrice = 0;
/*
int[] myIntArr = new int[10];   // Empty 10 long int array
int[] myIntArr2 = new int[] { 1, 2, 3 };
*/
int GetInt(string question)
{
    Console.WriteLine(question);
    string input = Console.ReadLine();
    int inputInt = int.Parse(input);
    return inputInt;
}

bool GetBool(string question)
{
    Console.WriteLine(question);
    string input = Console.ReadLine();
    bool inputBool = bool.Parse(input);
    return inputBool;
}

int GetIntPARCEL(string question, int min, int max)
{
    while (true) 
    { 
        Console.WriteLine(question);
        string input = Console.ReadLine();
        int inputInt = int.Parse(input);
        if (inputInt >= min && inputInt < max)
        {
            return inputInt;
        }
        else
        {
            Console.WriteLine("you are outside of the min and max");
        }
    }
}



Console.WriteLine("what is the delivery address");
Address = Console.ReadLine();

Console.WriteLine("What is the customer name");
Name = Console.ReadLine();

Console.WriteLine(" what is the customers phone number");
phonenumber = Console.ReadLine();



numberofparcels = GetIntPARCEL("How many parcels are being delivered", 1, 6);

for (int i = 0; i < numberofparcels; i++)
{
    // Get Info
    Height = GetInt  ("What is the height of the parcel");
    Length = GetInt ("What is the length of the parcel");
    Width =  GetInt ("what is the Width of the parcel");
    Signature[i] = GetBool("Does this parcel require a signature");
    parceltracking[i] = GetBool("does this parcel require tracking");
    Weight[i] = GetInt("what is the weight of your parcel");
    Console.WriteLine("-----------------------------------------------------");

    size[i] = Height + Width + Length;
    if (size[i] < 95 && Weight[i] < 2 )
    {
        price[i] = 5;
    }
    else if (size[i] < 150 && Weight[i] < 15)
    {
        price[i] = 20;
    }
    else if (size [i] < 450 && Weight[i] < 30)
    {
        price[i] = 30;
    }
    else
    {
        price[i] = 0;
        continue;
    }

    if (Signature[i])
    { price[i] += 2; }
    if (parceltracking[i])
    {
        price[i] += 5;
    }
    finalPrice += price[i];
}

Console.WriteLine(Name);
Console.WriteLine(Address);
Console.WriteLine(phonenumber);
Console.WriteLine(numberofparcels);
Console.WriteLine("----------------");
for (int i = 0; i < numberofparcels; i++)
{
    
    Console.WriteLine(price[i]);
    if (Signature[i])
    {
        Console.WriteLine("additional cost for signature2");
    }
    if (parceltracking[i])
    {
        Console.WriteLine("additional cost for tracking 5");
    }
    
   
}
Console.WriteLine("----------------------");
Console.WriteLine(finalPrice);



