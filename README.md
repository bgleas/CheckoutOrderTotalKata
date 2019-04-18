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


Use Cases:
1. Accept a scanned item. The total should reflect an increase by the per-unit price after the scan. You will need a way to configure the prices of scannable items prior to being scanned.
2. Accept a scanned item and a weight. The total should reflect an increase of the price of the item for the given weight.
3. Support a markdown. A marked-down item will reflect the per-unit cost less the markdown when scanned. A weighted item with a markdown will reflect that reduction in cost per unit.
4. Support a special in the form of "Buy N items get M at %X off." For example, "Buy 1 get 1 free" or "Buy 2 get 1 half off."
5. Support a special in the form of "N for $X." For example, "3 for $5.00"
6. Support a limit on specials, for example, "buy 2 get 1 free, limit 6" would prevent getting a third free item.
7. Support removing a scanned item, keeping the total correct after possibly invalidating a special.
8. Support "Buy N, get M of equal or lesser value for %X off" on weighted items.