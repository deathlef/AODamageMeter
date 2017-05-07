﻿using System;
using System.Text.RegularExpressions;

namespace AODamageMeter.FightEvents.Heal
{
    public class MeGotNano : HealEvent
    {
        public const string EventName = "Me got nano";
        public override string Name => EventName;

        public static readonly Regex
            Normal = CreateRegex($"You got nano from {SOURCE} for {AMOUNT} points.");

        public MeGotNano(Fight fight, DateTime timestamp, string description)
            : base(fight, timestamp, description)
        {
            SetTargetToOwner();
            HealType = HealType.Nano;

            if (TryMatch(Normal, out Match match))
            {
                // TODO: is the source always a player character?
                SetSource(match, 1);
                SetAmount(match, 2);
            }
            else IsUnmatched = true;
        }
    }
}
