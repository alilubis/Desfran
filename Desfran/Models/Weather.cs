namespace Desfran.Models
{
    public class Weather
    {
        public class Root
        {
            public string? Region { get; set; }
            public Currentconditions? CurrentConditions { get; set; }
            public Next_Days[]? Next_days { get; set; }
            public Contact_Author? Contact_author { get; set; }
            public string? Data_source { get; set; }
        }

        public class Currentconditions
        {
            public string? Dayhour { get; set; }
            public Temp? Temp { get; set; }
            public string? Precip { get; set; }
            public string? Humidity { get; set; }
            public Wind? Wind { get; set; }
            public string? IconURL { get; set; }
            public string? Comment { get; set; }
        }

        public class Temp
        {
            public int? C { get; set; }
            public int? F { get; set; }
        }

        public class Wind
        {
            public int? Km { get; set; }
            public int? Mile { get; set; }
        }

        public class Contact_Author
        {
            public string? Email { get; set; }
            public string? Auth_note { get; set; }
        }

        public class Next_Days
        {
            public string? Day { get; set; }
            public string? Comment { get; set; }
            public Max_Temp? Max_temp { get; set; }
            public Min_Temp? Min_temp { get; set; }
            public string? IconURL { get; set; }
        }

        public class Max_Temp
        {
            public int? C { get; set; }
            public int? F { get; set; }
        }

        public class Min_Temp
        {
            public int? C { get; set; }
            public int? F { get; set; }
        }


    }
}