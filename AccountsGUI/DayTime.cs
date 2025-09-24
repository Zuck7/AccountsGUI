using System;

namespace AccountsGUI
{
    public struct DayTime
    {
        private long minutes;

        public DayTime(long minutes)
        {
            this.minutes = minutes;
        }

        public static DayTime operator +(DayTime lhs, int addMinutes)
        {
            return new DayTime(lhs.minutes + addMinutes);
        }

        public override string ToString()
        {
            long totalMinutes = minutes;
            long year = 2023;
            long month = 1;
            long day = 1;
            long hour = 0;
            long minute = 0;

            year += totalMinutes / 518_400;
            totalMinutes %= 518_400;

            month += totalMinutes / 43_200;
            totalMinutes %= 43_200;

            day += totalMinutes / 1_440;
            totalMinutes %= 1_440;

            hour = totalMinutes / 60;
            minute = totalMinutes % 60;

            return $"{year:D4}-{month:D2}-{day:D2} {hour:D2}:{minute:D2}";
        }
    }
}
