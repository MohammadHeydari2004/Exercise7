///// Mohammad Heydari /////////
////// Shamsipour Technical and Vocational College (2023) //////////////

string inputaddress = @"D:\Shamsipoor\012\Digikala\orders.csv";
string input;
int digit;

Digikalatext context = new Digikalatext(inputaddress);
DigikalaOn op = new DigikalaOn(context.digikalas);
City city = new City();
Year year = new Year();

do
{
    Console.WriteLine("Based on what (sales volume) do you want? (1-year , 2-item , 3-Customer , 4-city)");

    if (int.TryParse(Console.ReadLine(), out digit) == true)
    {

        switch (digit)
        {
            case 1:
                Console.WriteLine("which year?");
                int input3;
                if (int.TryParse(Console.ReadLine(), out input3) == true)
                {
                    Console.WriteLine(op.SumSalesByYear(input3));
                    Console.WriteLine("Enter the year to receive the report again.");
                    year.GetYear();
                }
                else
                {
                    Console.WriteLine("Error");
                }
                break;

            case 2:
                Console.WriteLine("Which item?");
                int input5;
                if (int.TryParse(Console.ReadLine(), out input5) == true)
                {
                    foreach (var item in op.SearchByItem(input5))
                    {
                        Console.WriteLine("{0} {1} {2} {3}", item.ID_Customer, item.DateTime_CartFinalize, item.ID_Item, item.city_name_fa);
                        Console.WriteLine();

                    }
                }
                else
                {
                    Console.WriteLine("Error");
                }

                break;
            case 3:
                Console.WriteLine("Which Customer?");
                int input6;
                if (int.TryParse(Console.ReadLine(), out input6) == true)
                {
                    foreach (var item in op.SearchByUser(input6))
                    {
                        Console.WriteLine("{0} {1} {2}", item.DateTime_CartFinalize, item.ID_Item, item.city_name_fa);
                        Console.WriteLine();

                    }
                }
                else
                {
                    Console.WriteLine("Error");
                }

                break;

            case 4:
                Console.WriteLine("What city?");
                city.GetCity();
                break;

            default:
                Console.WriteLine("Please enter only the numbers 1,2,3,4 .");
                break;

        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Error");
    }

    Console.WriteLine();

    Console.WriteLine("Do you want to continue? Press Y or N: ");
    do
    {
        input = Console.ReadKey(true).KeyChar.ToString();
    }
    while (input.ToUpper() != "Y" && input.ToUpper() != "N");

} while (input.ToUpper() == "Y");

end();

void end()
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine();
    Console.WriteLine("Thanks for using this app");
    Console.ResetColor();
}

#region classes
class Digikala
{
    public int ID_Order { get; set; }
    public int ID_Customer { get; set; }
    public int ID_Item { get; set; }
    public DateTime DateTime_CartFinalize { get; set; }
    public int Amount_Gross_Order { get; set; }
    public string city_name_fa { get; set; }
}

class Digikalatext
{
    private Digikala digikala;
    private string line;

    public List<Digikala> digikalas { get; }
    public Digikalatext(string inputaddress)
    {

        digikalas = new List<Digikala>();

        using (StreamReader strread = new StreamReader(inputaddress))
        {
            strread.ReadLine();
            while (!strread.EndOfStream)
            {
                line = strread.ReadLine();
                digikala = new Digikala();

                digikala.ID_Order = Convert.ToInt32(line.Split(",")[0]);
                digikala.ID_Customer = Convert.ToInt32(line.Split(",")[1]);
                digikala.ID_Item = Convert.ToInt32(line.Split(",")[2]);
                digikala.DateTime_CartFinalize = Convert.ToDateTime(line.Split(",")[3]);
                digikala.Amount_Gross_Order = Convert.ToInt32(line.Split(",")[4].Replace(".0", ""));
                digikala.city_name_fa = line.Split(",")[5];

                digikalas.Add(digikala);
            }
        }
    }
}


class DigikalaOn
{
    List<Digikala> digikalas;
    public DigikalaOn(List<Digikala> digikalas)
    {
        this.digikalas = digikalas;
    }

    public List<Digikala> SearchByItem(int ID_Item)
    {
        return digikalas.Where(x => x.ID_Item == ID_Item).ToList();
    }


    public List<Digikala> SearchByUser(int ID_Customer)
    {
        return digikalas.Where(x => x.ID_Customer == ID_Customer).ToList();
    }

    public List<int> AllSalesByYear(int year)
    {
        return digikalas.Where(x => x.DateTime_CartFinalize.Year == year).Select(x => x.Amount_Gross_Order).ToList();
    }

    public long SumSalesByYear(int year)
    {
        List<int> sales = AllSalesByYear(year);
        long total = 0;

        foreach (int sale in sales)
        {
            total += sale;
        }

        return total;
    }


    public List<int> AllSalesByMonth(int Month)
    {
        return digikalas.Where(x => x.DateTime_CartFinalize.Month == Month).Select(x => x.Amount_Gross_Order).ToList();
    }

    public long SumSalesByMonth(int Month)
    {
        List<int> sales = AllSalesByYear(Month);
        long total = 0;

        foreach (int sale in sales)
        {
            total += sale;
        }

        return total;
    }

}
class City
{
    string inputaddress = @"D:\Shamsipoor\012\Digikala\orders.csv";
    public string GetCity()
    {

        StreamReader reader = new StreamReader(inputaddress);
        string input2 = Convert.ToString(Console.ReadLine());

        switch (input2.ToLower())
        {
            case "tehran":

                string outputaddress = @"D:\Shamsipoor\012\Digikala\تهران.txt";

                StreamWriter writer = new StreamWriter(outputaddress);
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line.Contains(",تهران,"))
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.Close();
                reader.Close();
                break;

            case "yazd":

                string outputaddress1 = @"D:\Shamsipoor\012\Digikala\یزد.txt";

                StreamWriter writer1 = new StreamWriter(outputaddress1);
                string line1;
                while (!reader.EndOfStream)
                {
                    line1 = reader.ReadLine();
                    if (line1.Contains(",یزد,"))
                    {
                        writer1.WriteLine(line1);
                    }
                }
                writer1.Close();
                reader.Close();
                break;

            case "khoy":

                string outputaddress2 = @"D:\Shamsipoor\012\Digikala\خوی.txt";

                StreamWriter writer2 = new StreamWriter(outputaddress2);
                string line2;
                while (!reader.EndOfStream)
                {
                    line2 = reader.ReadLine();
                    if (line2.Contains(",خوی,"))
                    {
                        writer2.WriteLine(line2);
                    }
                }
                writer2.Close();
                reader.Close();
                break;

            case "marand":

                string outputaddress3 = @"D:\Shamsipoor\012\Digikala\مرند.txt";

                StreamWriter writer3 = new StreamWriter(outputaddress3);
                string line3;
                while (!reader.EndOfStream)
                {
                    line3 = reader.ReadLine();
                    if (line3.Contains(",مرند,"))
                    {
                        writer3.WriteLine(line3);
                    }
                }
                writer3.Close();

                break;

            case "urmia":

                string outputaddress4 = @"D:\Shamsipoor\012\Digikala\ارومیه.txt";

                StreamWriter writer4 = new StreamWriter(outputaddress4);
                string line4;
                while (!reader.EndOfStream)
                {
                    line4 = reader.ReadLine();
                    if (line4.Contains(",ارومیه,"))
                    {
                        writer4.WriteLine(line4);
                    }
                }
                writer4.Close();
                reader.Close();
                break;

            case "tabriz":

                string outputaddress5 = @"D:\Shamsipoor\012\Digikala\تبریز.txt";

                StreamWriter writer5 = new StreamWriter(outputaddress5);
                string line5;
                while (!reader.EndOfStream)
                {
                    line5 = reader.ReadLine();
                    if (line5.Contains(",تبریز,"))
                    {
                        writer5.WriteLine(line5);
                    }
                }
                writer5.Close();
                reader.Close();
                break;

            case "maragheh":

                string outputaddress6 = @"D:\Shamsipoor\012\Digikala\مراغه.txt";

                StreamWriter writer6 = new StreamWriter(outputaddress6);
                string line6;
                while (!reader.EndOfStream)
                {
                    line6 = reader.ReadLine();
                    if (line6.Contains(",مراغه,"))
                    {
                        writer6.WriteLine(line6);
                    }
                }
                writer6.Close();
                reader.Close();
                break;

            case "ahar":

                string outputaddress7 = @"D:\Shamsipoor\012\Digikala\اهر.txt";

                StreamWriter writer7 = new StreamWriter(outputaddress7);
                string line7;
                while (!reader.EndOfStream)
                {
                    line7 = reader.ReadLine();
                    if (line7.Contains(",اهر,"))
                    {
                        writer7.WriteLine(line7);
                    }
                }
                writer7.Close();
                reader.Close();
                break;

            case "ardabil":

                string outputaddress8 = @"D:\Shamsipoor\012\Digikala\اردبیل.txt";

                StreamWriter writer8 = new StreamWriter(outputaddress8);
                string line8;
                while (!reader.EndOfStream)
                {
                    line8 = reader.ReadLine();
                    if (line8.Contains(",اردبیل,"))
                    {
                        writer8.WriteLine(line8);
                    }
                }
                writer8.Close();
                reader.Close();
                break;

            case "garmdareh":

                string outputaddress95 = @"D:\Shamsipoor\012\Digikala\گرمدره.txt";

                StreamWriter writer95 = new StreamWriter(outputaddress95);
                string line95;
                while (!reader.EndOfStream)
                {
                    line95 = reader.ReadLine();
                    if (line95.Contains(",گرمدره,"))
                    {
                        writer95.WriteLine(line95);
                    }
                }
                writer95.Close();
                reader.Close();
                break;

            case "golestan":

                string outputaddress94 = @"D:\Shamsipoor\012\Digikala\گلستان.txt";

                StreamWriter writer94 = new StreamWriter(outputaddress94);
                string line94;
                while (!reader.EndOfStream)
                {
                    line94 = reader.ReadLine();
                    if (line94.Contains(",گلستان,"))
                    {
                        writer94.WriteLine(line94);
                    }
                }
                writer94.Close();
                reader.Close();
                break;
            case "malard":

                string outputaddress88 = @"D:\Shamsipoor\012\Digikala\ملارد.txt";

                StreamWriter writer88 = new StreamWriter(outputaddress88);
                string line88;
                while (!reader.EndOfStream)
                {
                    line88 = reader.ReadLine();
                    if (line88.Contains(",ملارد,"))
                    {
                        writer88.WriteLine(line88);
                    }
                }
                writer88.Close();
                reader.Close();
                break;

            default:
                Console.WriteLine("The entered city is not entered correctly or is not defined in this program.");
                break;
        }
        return input2;
    }

}

class Year
{
    public int GetYear()
    {
        string inputaddress = @"D:\Shamsipoor\012\Digikala\orders.csv";

        int input3;
        if (int.TryParse(Console.ReadLine(), out input3) == true)
        {
            switch (input3)
            {

                case 2013:

                    string outputaddress = @"D:\Shamsipoor\012\Digikala\2013.txt";
                    StreamReader reader = new StreamReader(inputaddress);
                    StreamWriter writer = new StreamWriter(outputaddress);
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (line.Contains("2013-"))
                        {
                            writer.WriteLine(line);
                        }
                    }
                    writer.Close();
                    reader.Close();
                    break;

                case 2014:

                    string outputaddress1 = @"D:\Shamsipoor\012\Digikala\2014.txt";
                    StreamReader reader1 = new StreamReader(inputaddress);
                    StreamWriter writer1 = new StreamWriter(outputaddress1);
                    string line1;
                    while (!reader1.EndOfStream)
                    {
                        line1 = reader1.ReadLine();
                        if (line1.Contains("2014-"))
                        {
                            writer1.WriteLine(line1);
                        }
                    }
                    writer1.Close();
                    reader1.Close();
                    break;

                case 2015:

                    string outputaddress2 = @"D:\Shamsipoor\012\Digikala\2015.txt";
                    StreamReader reader2 = new StreamReader(inputaddress);
                    StreamWriter writer2 = new StreamWriter(outputaddress2);
                    string line2;
                    while (!reader2.EndOfStream)
                    {
                        line2 = reader2.ReadLine();
                        if (line2.Contains("2015-"))
                        {
                            writer2.WriteLine(line2);
                        }
                    }
                    writer2.Close();
                    reader2.Close();
                    break;

                case 2016:

                    string outputaddress3 = @"D:\Shamsipoor\012\Digikala\2016.txt";
                    StreamReader reader3 = new StreamReader(inputaddress);
                    StreamWriter writer3 = new StreamWriter(outputaddress3);
                    string line3;
                    while (!reader3.EndOfStream)
                    {
                        line3 = reader3.ReadLine();
                        if (line3.Contains("2016-"))
                        {
                            writer3.WriteLine(line3);
                        }
                    }
                    writer3.Close();
                    reader3.Close();
                    break;

                case 2017:

                    string outputaddress4 = @"D:\Shamsipoor\012\Digikala\2017.txt";
                    StreamReader reader4 = new StreamReader(inputaddress);
                    StreamWriter writer4 = new StreamWriter(outputaddress4);
                    string line4;
                    while (!reader4.EndOfStream)
                    {
                        line4 = reader4.ReadLine();
                        if (line4.Contains("2017-"))
                        {
                            writer4.WriteLine(line4);
                        }
                    }
                    writer4.Close();
                    reader4.Close();
                    break;

                case 2018:

                    string outputaddress5 = @"D:\Shamsipoor\012\Digikala\2018.txt";
                    StreamReader reader5 = new StreamReader(inputaddress);
                    StreamWriter writer5 = new StreamWriter(outputaddress5);
                    string line5;
                    while (!reader5.EndOfStream)
                    {
                        line5 = reader5.ReadLine();
                        if (line5.Contains("2018-"))
                        {
                            writer5.WriteLine(line5);
                        }
                    }
                    writer5.Close();
                    reader5.Close();
                    break;

                default:
                    Console.WriteLine("Please enter the year, for example 2013 (if you have entered the year, then that year is not defined in this program.)");

                    break;
            }

        }
        else
        {
            Console.WriteLine("Error");
        }
        return input3;
    }
}

#endregion