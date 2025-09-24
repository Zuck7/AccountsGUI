namespace AccountsGUI;
static class Util
{
    private static Random random = new Random();

    private static DayTime currentTime = new DayTime(1169280);

    public static DayTime Now
    {
        get
        {
            currentTime = currentTime + random.Next(100);
            return currentTime;
        }
    }
}

