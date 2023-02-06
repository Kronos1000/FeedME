using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FeedME
{
    public class Program
    {
        public static void Banner() // display banner when required 
        {

            string FeedMeBanner = @"
  ______            _   __  __      
 |  ____|          | | |  \/  |     
 | |__ ___  ___  __| | | \  / | ___ 
 |  __/ _ \/ _ \/ _` | | |\/| |/ _ \
 | | |  __/  __/ (_| | | |  | |  __/
 |_|  \___|\___|\__,_| |_|  |_|\___|
                                    
                                    ";
            Console.Clear();
            Console.WriteLine(FeedMeBanner);


        }

        public static void Main(string[] args)
        {


            MainMenu();
        }

        public static void MainMenu()
        {
            Banner();
            Console.WriteLine("Please enter the number of the option you require");
            Console.WriteLine("[1] Create New Shopping List");
            Console.WriteLine("[2] Add  Dinner Items To current  Shopping List");

            Console.WriteLine("[3] View Current Shopping List");
            Console.WriteLine("[4] Add new Dinner Recipe");
            Console.WriteLine("[5] Remove Duplicate Items from list");
            Console.WriteLine("[6]Add regular items to shopping list");
            Console.WriteLine("[7] Erase Current Shopping List");
            string MenuChoice = Console.ReadLine();

            if (MenuChoice == "1")
            {
                CreateNewShoppingList();
            }

            if (MenuChoice == "2")
            {
                AddToCurrentShoppingList();
            }

            if (MenuChoice == "3")
            {
                showCurrentList();
            }

            if (MenuChoice == "4")
            {
                AddNewRecipe();
            }

            if (MenuChoice == "5")
            {
                RemoveDuplicateItems();
            }
            if (MenuChoice == "6")
            {
                AddRegularItemsToShoppingList();
            }

            if (MenuChoice == "7")
            {
               EraseCurrentShoppingList();
            }
        }

        private static void AddRegularItemsToShoppingList()
        {

            Banner();
            Console.WriteLine("Please enter the items you require sepereated by  a comma");
            string itemsRequired = Console.ReadLine();
            itemsRequired = itemsRequired + ",";
            itemsRequired = itemsRequired.Replace(",", "\n");

            using (StreamWriter writer = File.AppendText("./ShoppingList.txt"))
            {
                writer.WriteLine(itemsRequired);
            }
            Banner();
            showCurrentList();
        }

   

            private static void CreateNewShoppingList()
        {
            Banner();
            List<Dinner> DinnerList = GetDinnerData();
            Dinner[] dinnerArray = DinnerList.ToArray();
       
            
            
            int Dcount = 0;
            Console.WriteLine("What would you like for dinner this week");
            foreach (Dinner dinner in dinnerArray)
            {
                Console.WriteLine("["+Dcount+"]" +dinner.Recipe);
                Dcount++;
            }
           int DinnerChoice = int.Parse(Console.ReadLine());

            using (StreamWriter writer = File.CreateText("./ShoppingList.txt"))
            {
                string addItems = dinnerArray[DinnerChoice].Ingredients.ToString();
                addItems = addItems + "," + dinnerArray[DinnerChoice].Meat;
                addItems = addItems.Replace(',', '\n');
                writer.WriteLine(addItems);
            }

            showCurrentList();


        }


        public static void showCurrentList()
        {
          
            string ShoppingList = File.ReadAllText("./ShoppingList.txt");
            Banner();

      
      

                Console.WriteLine("Your Current Shopping List is as Follows:");

                Console.WriteLine(ShoppingList);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press enter to return to the main menu");
                Console.ReadLine();
                MainMenu();
            
        }


        public static void EraseCurrentShoppingList()
        {
       
            using (StreamWriter writer = File.CreateText("./ShoppingList.txt"))
            {
                
                writer.WriteLine();
            }

            Banner();
            Console.WriteLine("Your shopping list is now empty");
            Console.WriteLine();
            Console.WriteLine("Press ENTER to return to main menu");
            Console.ReadLine();
            MainMenu();


        }
        private static void AddToCurrentShoppingList()
        {
            Banner();
            List<Dinner> DinnerList = GetDinnerData();
            Dinner[] dinnerArray = DinnerList.ToArray();
            int Dcount = 0;
            Console.WriteLine("What would you like for dinner this week");
            foreach (Dinner dinner in dinnerArray)
            {
                Console.WriteLine("[" + Dcount + "]" + dinner.Recipe);
                Dcount++;
            }
            int DinnerChoice = int.Parse(Console.ReadLine());

            using (StreamWriter writer = File.AppendText("./ShoppingList.txt"))
            {
                string addItems = dinnerArray[DinnerChoice].Ingredients.ToString();

                addItems = addItems + "," + dinnerArray[DinnerChoice].Meat;
                addItems = addItems.Replace(',', '\n');
                writer.WriteLine(addItems);
            }

            showCurrentList();

        }
        public static void RemoveDuplicateItems()
        {
            List<string> GroceryList = System.IO.File.ReadLines("./ShoppingList.txt").Distinct().ToList();
            using (StreamWriter writer = File.CreateText("./ShoppingList.txt"))
            {
                foreach (string Grocery in GroceryList)
                {
                    writer.WriteLine(Grocery);
                }
            }
            showCurrentList();
        }

        public static void ShowAvailiableDinnerOptions()
        {
            {
                Banner();
                List<Dinner> DinnerList = GetDinnerData();
                Dinner[] dinnerArray = DinnerList.ToArray();
                int Dcount = 0;
                Console.WriteLine("The Following Dinner Options are Currently Availiable");
                foreach (Dinner dinner in dinnerArray)
                {
                    Console.WriteLine("[" + Dcount + "]" + dinner.Recipe);
                    Dcount++;
                }
            }

        }
        public static void AddNewRecipe()
        {
            Banner();
            Console.WriteLine("Please Enter the name of the dinner you wish to add");
            string Recipe = Console.ReadLine();
            Banner();
            Console.WriteLine("Please enter the recipe base  that is used to create this dish");
            string RecipeBase = Console.ReadLine();
            Banner();
            Console.WriteLine("Please enter the meat used in this dish (If none if used enter N/A)");
            string Meat = Console.ReadLine();
            Banner();
            Console.WriteLine("Please enter all ingredients (except the meat) That are needed to prepare this dish seperated by a Comma");
            string Ingredients= Console.ReadLine();
            Banner();
            string RecipeToADD = Recipe + "|" + RecipeBase + "|" + Meat + "|" + Ingredients+',';
            string RequiredIngredients = RecipeBase +"," + Meat  +","+ Ingredients;

            RequiredIngredients = RequiredIngredients.Replace(',', '\n');
            using (StreamWriter writer = File.AppendText("./DinnerFood.txt"))
            {
                writer.WriteLine(RecipeToADD);
            }

            Console.WriteLine("You have Added the Following Recipe to the Menu:");
            Console.WriteLine(Recipe);
           
            Console.WriteLine("Which requires the Following ingredients:");
            Console.WriteLine(RequiredIngredients);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press ENTER to show updated dinner Choices");
            Console.ReadLine();
            ShowAvailiableDinnerOptions();


            Console.WriteLine("Press ENTER to return to the main menu");
            Console.ReadLine(); // pause before calling main menu method 

            MainMenu();

        }

        public static  List<Dinner> GetDinnerData()
        {
            List<Dinner> DinnerList = new List<Dinner>();

            using (StreamReader reader = new StreamReader("./DinnerFood.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string [] parts = line.Split('|');
                    string recipe= parts[0];
                    string recipeBase = parts[1];
                    string meat = parts[2];
                    string ingredients = parts[3];

                    Dinner D = new Dinner(recipe, recipeBase, meat, ingredients);
                    DinnerList.Add(D);
                }
                

            }

                return DinnerList;
        }

        public static List<RegularItem> GetRegularItemData()
        {
            List<RegularItem> RegularItemList = new List<RegularItem>();

            using (StreamReader reader = new StreamReader("./RegularItem.txt"))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('|');
                    string ItemName = parts[0];
                    string ItemDescription = parts[1];


                    RegularItem R = new RegularItem (ItemName, ItemDescription);
                    RegularItemList.Add(R);
                }
            }


            return RegularItemList;
        }

    }



    }

