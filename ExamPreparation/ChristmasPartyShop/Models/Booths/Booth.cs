﻿using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            this.boothId = boothId;
            this.capacity = capacity;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
        }

        public int BoothId { get => boothId; private set => boothId = value; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value >= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu { get => delicacyMenu; private set => delicacyMenu = value; }

        public IRepository<ICocktail> CocktailMenu { get => cocktailMenu; private set => cocktailMenu = value; }

        public double CurrentBill { get => currentBill; private set => currentBill = value; }

        public double Turnover { get => turnover; private set => turnover = value; }

        public bool IsReserved { get => isReserved; private set => isReserved = value; }

        public void ChangeStatus()
        {
            if (isReserved)
            {
                isReserved = false;
            }
            IsReserved = true;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");
            foreach (var item in CocktailMenu.Models)
            {
                sb.AppendLine($"--{item}");
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var item in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
