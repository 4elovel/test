internal class Program
{
    public class Counter
    {
        public int counter;
        public Counter()
        {
            counter = 0;
        }
    }
    public class MyTime
    {
        public DateTime time = DateTime.UtcNow;
    }
    private static void Main(string[] args)
    {
        Counter counter = new Counter();
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.Run(async (context) =>
        {
            MyTime time = new MyTime();
            counter.counter++;
            string html = "";
            html += $"<p>{counter.counter}</p>";
            html += $"<p>{time.time.ToString()}</p>";
            var responce = context.Response;
            for (int i = 1; i <= 10; i++)
            {
                html += $"<p>Œ·'∫ÍÚ {i}</p>";
            }
            responce.ContentType = "text/html; charset=utf-8";
            html += $"<p>{responce.Headers}</p>";
            foreach (var i in responce.Headers)
            {
                html += $"<tr><td>{i.Key}</td><td>{i.Value}</td></tr>";
            }
            var query = context.Request.Query;
            string firstname = query["firstname"];
            string age = query["age"];
            string lastname = query["lastname"];
            string hair = query["hair"];
            string height = query["height"];
            string weight = query["weight"];
            if (firstname != null) html += $"<p>firstname - {firstname}</p>";
            if (age != null) html += $"<p>age - {age}</p>";
            if (lastname != null) html += $"<p>lastname - {lastname}</p>";
            if (hair != null) html += $"<p>hair - {hair}</p>";
            if (height != null) html += $"<p>height - {height}</p>";
            if (weight != null) html += $"<p>weight - {weight}</p>";

            await responce.WriteAsync(html);
        });
        app.Run();
    }

}