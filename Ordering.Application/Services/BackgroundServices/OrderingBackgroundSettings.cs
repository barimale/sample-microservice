﻿namespace Ordering.Application.Services.BackgroundServices
{
    public class OrderingBackgroundSettings
    {
        public OrderingBackgroundSettings()
        {
            // intentionally left blank
        }

        public int CheckUpdateTime { get; set; } = 1000;
    }
}