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

  public void DisplayOnStart()
  {
    Console.WriteLine(Welcome);
    Console.Write(Menu);
    Console.WriteLine("Write Selection below and press Enter: ");
    int selection = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Write Quantity and press Enter: ");

    int quantity = Int32.Parse(Console.ReadLine());
    int total;
    if(selection ==1)
    {
      Bread toBuy = new Bread();
      total = toBuy.GetTotal(quantity);
      DisplayOrderSummary(toBuy, quantity, total);
    } else if (selection == 2)
    {
      Pastry toBuy = new Pastry();
      total = toBuy.GetTotal(quantity);
      DisplayOrderSummary(toBuy, quantity, total);
    }
  }
  public void DisplayOrderSummary(IProduct item, int quantity, int total)
  {
    Console.WriteLine("Item: " + item.Type);
    Console.WriteLine("Quantity: " + quantity);
    Console.WriteLine("Total: $" + total + ".00");
  }
 
  }
}