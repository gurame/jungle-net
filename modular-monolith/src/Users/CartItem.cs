﻿using Ardalis.GuardClauses;

namespace Users;

public class CartItem
{
  public CartItem(Guid bookId, string description, int quantity, decimal unitPrice)
  {
    BookId = Guard.Against.Default(bookId);
    Description = Guard.Against.NullOrEmpty(description);
    Quantity = Guard.Against.Negative(quantity);
    UnitPrice = Guard.Against.Negative(unitPrice);
  }
  public Guid Id { get; private set; }
  public Guid BookId { get; private set; }
  public string Description { get; private set; } = string.Empty;
  public int Quantity { get; private set; }
  public decimal UnitPrice { get; private set; }

  public void UpdateQuantity(int quantity)
  {
    Quantity = Guard.Against.Negative(quantity);
  }

  public void UpdateDescription(string description)
  {
    Description = Guard.Against.NullOrEmpty(description);
  }

  public void UpdatePrice(decimal unitPrice)
  {
    UnitPrice = Guard.Against.Negative(unitPrice);
  }
}
