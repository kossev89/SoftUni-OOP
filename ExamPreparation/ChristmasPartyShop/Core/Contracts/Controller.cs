using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core.Contracts
{
    public class Controller : IController
    {
        private BoothRepository booths;
        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            var currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            else if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            else if (currentBooth.CocktailMenu.Models.FirstOrDefault(x => x.Name == cocktailName && x.Size == size) != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }
            if (cocktailTypeName == "Hibernation")
            {
                Hibernation hibernation = new Hibernation(cocktailName, size);
                currentBooth.CocktailMenu.AddModel(hibernation);
            }
            else
            {
                MulledWine mulledWine = new MulledWine(cocktailName, size);
                currentBooth.CocktailMenu.AddModel(mulledWine);
            }
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            else if (currentBooth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == delicacyName) != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            if (delicacyTypeName == "Gingerbread")
            {
                Gingerbread gingerbread = new Gingerbread(delicacyName);
                currentBooth.DelicacyMenu.AddModel(gingerbread);
            }
            else
            {
                var stolen = new Stolen(delicacyName);
                currentBooth.DelicacyMenu.AddModel(stolen);
            }
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);

        }

        public string BoothReport(int boothId)
        {
            IBooth currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            return currentBooth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            currentBooth.Charge();
            currentBooth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBooth.Turnover:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .First();
            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderArguments = order
                .Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderArguments[0];
            string itemName = orderArguments[1];
            int count = int.Parse(orderArguments[2]);

            IBooth currentBooth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (
                itemTypeName != "Gingerbread"
                && itemTypeName != "Stolen"
                && itemTypeName != "Hibernation"
                && itemTypeName != "MulledWine"
                )
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
            else if (
                itemTypeName == "Gingerbread"
                ||
                itemTypeName == "Stolen"
                || itemTypeName == "Hibernation"
                || itemTypeName == "MulledWine"
                )
            {
                if (
                    currentBooth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName) == null
                    && currentBooth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName) == null
                    )
                {

                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
            }
            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                string size = orderArguments[3];
                if (currentBooth.CocktailMenu.Models.FirstOrDefault
                    (
                    x => x.GetType().Name == itemTypeName
                    && x.Name == itemName
                    && x.Size == size
                    )
                    == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }
                ICocktail cocktail = currentBooth.CocktailMenu.Models.FirstOrDefault
                    (
                    x => x.GetType().Name == itemTypeName
                    && x.Name == itemName
                    && x.Size == size
                    );
                currentBooth.UpdateCurrentBill(cocktail.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }
            else
            {
                if (currentBooth.DelicacyMenu.Models.FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName) == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
                else
                {
                    IDelicacy delicacy = currentBooth.DelicacyMenu.Models.FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName);
                    currentBooth.UpdateCurrentBill(delicacy.Price * count);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                }
            }

        }
    }
}
