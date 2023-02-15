  public record ItemRequest (
                    string Id,
                      string Description,
                      float QuantityOnHand,
                      float SellingPrice,
                      float CostPrice,
                      string CostCode,
                      int ReorderLevel
                      );
