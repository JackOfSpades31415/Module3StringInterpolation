// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
      // create data file
      StreamWriter sw = new StreamWriter("data.txt");

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    Console.WriteLine(dataDate);
     // random number generator
    Random rnd = new Random();

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // TODO: parse data file
   double tot = 0;
   double avg = 0;
    if(System.IO.File.Exists("data.txt")){
        StreamReader sr = new StreamReader("data.txt");
        while(!sr.EndOfStream){
            string line = sr.ReadLine();
            string[] arr1 = line.Split(",");
            string[] arr2 = arr1[1].Split("|");
            Console.WriteLine("Week of {0:MM, dd, yyyy}", arr1[0]);
            Console.WriteLine("Su Mo Tu We Th Fr Sa Tot Avg");
            for(int i = 0; i < arr2.Length + 2; i++){
                if(i < arr2.Length){
                Console.Write("-- ");
                }
                else{
                Console.Write("--- ");
                }
            }
                Console.WriteLine("");
            for(int i = 0; i < arr2.Length; i++){
                Console.Write($"{arr2[i], -2} ");
            }
            for(int i = 0; i < arr2.Length; i++){
                tot = tot + Double.Parse(arr2[i]);
            }
            Console.Write($"{tot, -4}");
            avg = tot / arr2.Length;
            Console.Write("{0:F1}", avg);
            Console.WriteLine("\n");
            
        }
    }

}