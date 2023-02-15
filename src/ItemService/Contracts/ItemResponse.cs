  public record ItemResponse (
                    string Id,
                      string Description,
                      float QuantityOnHand,
                      float SellingPrice,
                      float CostPrice,
                      string CostCode,
                      int ReorderLevel
                      );
