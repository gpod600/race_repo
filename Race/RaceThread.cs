using Race.Data;

namespace Race
{
    class RaceThread
    {
        public static RaceInfo RaceInfo { get; set; }
        public static void Run()
        {
            MainWindow Window = new MainWindow(RaceInfo);
            Window.ShowDialog();
        }
        public int Data;
        public void DoRun()
        {
            
        }
    }
}
