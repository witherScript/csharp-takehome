using System;
using System.Collections.Generic;
using Bakery.Models.Config;

namespace Bakery.Models.UserInterfaceModels
{
  public class Banner
  {
    public string Welcome{get; }=
    @"

@@@@@@@   @@@  @@@@@@@@  @@@@@@@   @@@@@@@   @@@@@@@@  @@@   @@@@@@      @@@@@@@    @@@@@@   @@@  @@@  @@@@@@@@  @@@@@@@   @@@ @@@              
@@@@@@@@  @@@  @@@@@@@@  @@@@@@@@  @@@@@@@@  @@@@@@@@   @@  @@@@@@@      @@@@@@@@  @@@@@@@@  @@@  @@@  @@@@@@@@  @@@@@@@@  @@@ @@@              
@@!  @@@  @@!  @@!       @@!  @@@  @@!  @@@  @@!       @!   !@@          @@!  @@@  @@!  @@@  @@!  !@@  @@!       @@!  @@@  @@! !@@              
!@!  @!@  !@!  !@!       !@!  @!@  !@!  @!@  !@!            !@!          !@   @!@  !@!  @!@  !@!  @!!  !@!       !@!  @!@  !@! @!!              
@!@@!@!   !!@  @!!!:!    @!@!!@!   @!@!!@!   @!!!:!         !!@@!!       @!@!@!@   @!@!@!@!  @!@@!@!   @!!!:!    @!@!!@!    !@!@!               
!!@!!!    !!!  !!!!!:    !!@!@!    !!@!@!    !!!!!:          !!@!!!      !!!@!!!!  !!!@!!!!  !!@!!!    !!!!!:    !!@!@!      @!!!               
!!:       !!:  !!:       !!: :!!   !!: :!!   !!:                 !:!     !!:  !!!  !!:  !!!  !!: :!!   !!:       !!: :!!     !!:                
:!:       :!:  :!:       :!:  !:!  :!:  !:!  :!:                !:!      :!:  !:!  :!:  !:!  :!:  !:!  :!:       :!:  !:!    :!:                
 ::        ::   :: ::::  ::   :::  ::   :::   :: ::::       :::: ::       :: ::::  ::   :::   ::  :::   :: ::::  ::   :::     ::                
 :        :    : :: ::    :   : :   :   : :  : :: ::        :: : :       :: : ::    :   : :   :   :::  : :: ::    :   : :     :                 
                                                                                                                                                
                                                                                                                                                
                                                                                                                                                
@@!    !@@  @@!    !@@  @@!    !@@  @@!    !@@  @@!    !@@  @@!    !@@  @@!    !@@  @@!    !@@  @@!    !@@  @@!    !@@  @@!    !@@ 
 !@!  @!!    !@!  @!!    !@!  @!!    !@!  @!!    !@!  @!!    !@!  @!!    !@!  @!!    !@!  @!!    !@!  @!!    !@!  @!!    !@!  @!!   
  !@@!@!      !@@!@!      !@@!@!      !@@!@!      !@@!@!      !@@!@!      !@@!@!      !@@!@!      !@@!@!      !@@!@!      !@@!@!  
@!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!  @!@!@!!@!!
  !: :!!      !: :!!      !: :!!      !: :!!      !: :!!      !: :!!      !: :!!      !: :!!      !: :!!      !: :!!      !: :!!   
    ";

    public string Menu {get;} = 
    @" Please Choose from the Following Menu Options: 

      1. Bread
      2. Pastry
    ";

   public static void DisplayOnStart()
    {
        char complete = 'n';
        int finalTotal = 0;
        List<IProduct> products = new List<IProduct>();
        string Welcome = "Welcome to Our Shop";
        string Menu = "1. Bread\n2. Pastry";

        Console.WriteLine(Welcome);
        Console.WriteLine(Menu);
        while(complete != 'y' && complete != 'Y'){
            Console.WriteLine("Write Selection below and press Enter: ");
            string? input = Console.ReadLine();
            if(string.IsNullOrEmpty(input)){
              Console.WriteLine("Selection cannot be empty.");
              continue;
            }
            int selection;
            if(!int.TryParse(input, out selection)) {
              Console.WriteLine("Invalid selection. Please enter a valid number.");
              continue;
            }
            Console.WriteLine("Write Quantity and press Enter: ");
            string? input2 = Console.ReadLine();

            if(string.IsNullOrEmpty(input2))
            {
              Console.WriteLine("Quantity cannot be empty.");
              continue;
            }
            int quantity;
            if(!int.TryParse(input2, out quantity)) {
              Console.WriteLine("Invalid quantity. Please enter a valid number.");
              continue;
            }


            if(selection == 1)
            {
              Bread toBuy = new Bread();
              int itemTotal = toBuy.GetTotal(quantity);
              finalTotal += itemTotal;
              toBuy.Quantity = quantity;
              products.Add(toBuy);
            }
            else if (selection == 2)
            {
              Pastry toBuy = new Pastry();
              int itemTotal = toBuy.GetTotal(quantity);
              finalTotal += itemTotal;
              toBuy.Quantity = quantity;
              products.Add(toBuy);
            }

          Console.WriteLine("Does this complete your order? enter 'y' or 'Y' for yes. Press any other key to add more items.");
          complete = Console.ReadKey().KeyChar;
          Console.WriteLine();
        }

      DisplayOrderSummary(products.ToArray(), finalTotal);
    }

      public static void DisplayOrderSummary(IProduct[] items, int total)
    {
      foreach (var item in items)
      {
          int itemTotal = item.GetTotal(item.Quantity);
          Console.WriteLine("Item: " + item.Type);
          Console.WriteLine("Quantity: " + item.Quantity);
          Console.WriteLine("Subtotal: $" + itemTotal + ".00");
      }
      Console.WriteLine("Total: $" + total + ".00");
    }
 
  }
}