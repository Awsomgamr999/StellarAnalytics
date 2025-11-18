using StarMap.API;
using Brutal.ImGuiApi;
using KSA;
using System.Diagnostics;

namespace StellarAnalytics
{
    [StarMapMod]
    public class StellarAnalytics
    {
        private Stopwatch gameSession = new Stopwatch();
        private bool started = false;

        private string filePathAll = string.Empty;
        private long ticks = 0;

        [StarMapImmediateLoad]
        public void Init(Mod mod)
        {
            // Setup paths
            string writeDir = "StellarAnalyticsFiles";
            string writeFile = "timeFile.txt";
            string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderDirectory = Path.Combine(userDirectory, writeDir);
            filePathAll = Path.Combine(folderDirectory, writeFile);

            // Ensure directory exists
            if (!Directory.Exists(folderDirectory))
                Directory.CreateDirectory(folderDirectory);

            // Ensure file exists
            if (!File.Exists(filePathAll))
            {
                File.WriteAllText(filePathAll, "0");
            }

            // Load previous ticks safely
            string prevTime = File.ReadAllText(filePathAll).Trim();
            if (!long.TryParse(prevTime, out ticks))
                ticks = 0;

            Console.WriteLine($"Loaded previous playtime ticks: {ticks}");
        }

        [StarMapBeforeGui]
        public void OnBeforeUI(double dt)
        {
            if (!started)
            {
                gameSession.Start();
                started = true;
            }
        }

        [StarMapAfterGui]
        public void OnAfterUI(double dt)
        {
            TimeSpan session = gameSession.Elapsed;
            TimeSpan past = TimeSpan.FromTicks(ticks);
            TimeSpan total = past + session;

            string formattedSession =
                $"{session.Days:D0}:{session.Hours:D2}:{session.Minutes:D2}:{session.Seconds:D2}";

            string formattedTotal =
                $"{total.Days:D0}:{total.Hours:D2}:{total.Minutes:D2}:{total.Seconds:D2}";

            ImGui.Begin("Metrics");
            ImGui.Text("Current Session Time: " + formattedSession);
            ImGui.Text("Total Time Played: " + formattedTotal);
            ImGui.End();
        }

        [StarMapUnload]
        public void Unload()
        {
            TimeSpan past = TimeSpan.FromTicks(ticks);
            TimeSpan session = gameSession.Elapsed;

            // Combine and save
            TimeSpan total = past + session;
            File.WriteAllText(filePathAll, total.Ticks.ToString());

            Console.WriteLine($"Saved total playtime ticks: {total.Ticks}");
        }
    }
}
