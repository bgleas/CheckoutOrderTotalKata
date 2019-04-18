# CheckoutOrderTotalKata
Checkout Order Total Kata

C# Console App (.NET Core)

To run test cases execute the following command:
dotnet test CheckoutOrderTotalKata/CheckoutOrderTests/

Assumptions Made:
1.  You cannot add item to available items twice.  If the same item name is added it will throw error.
2.  Criteria 8: Buy N get M Of Equal Or Lesser Value for X Off
	N and M are different item types.  If they are same item type it makes sense to use a different special
3.  Items scanned that are not in system throws error.
4.  In Specials Buy N Items Get M At X Off Special and Buy N For X Special, N is an integer and is valid only for per unit items not weighted items.
