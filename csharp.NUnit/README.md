
# Gilded Rose Kata - Testing Strategy and Execution

## Testing Strategy

The goal of our testing strategy is to ensure the correctness of the `UpdateQuality` method in the Gilded Rose Kata. The strategy includes:

1. **Unit Tests**:
    - Each test focuses on a specific behavior of an item type.
    - Tests are written using NUnit.

2. **Edge Cases**:
    - Quality boundaries (`Quality = 0`, `Quality = 50`).
    - Negative `SellIn` values.

3. **Special Cases**:
    - "Aged Brie" increases in quality over time.
    - "Sulfuras" remains unchanged.
    - "Backstage passes" exhibit complex behavior:
        - Increase in quality as `SellIn` approaches.
        - Drop to zero after the concert.
    - "Conjured" items degrade twice as fast.

4. **Regression Tests**:
    - Tests ensure that no changes break existing functionality.

## Test Scenarios

| Scenario                                    | Expected Behavior                             |
|---------------------------------------------|-----------------------------------------------|
| Normal item quality degrades before SellIn  | Quality decreases by 1 each day.              |
| "Aged Brie" increases quality               | Quality increases by 1 each day until max 50. |
| "Sulfuras" remains unchanged                | Quality and SellIn do not change.             |
| "Backstage passes" increase and drop to 0   | Quality increases; drops to 0 after the concert. |
| "Conjured" items degrade faster             | Quality decreases by 2 each day.              |
| Quality never exceeds 50                    | Quality is capped at 50.                      |
| Quality never drops below 0                 | Quality is floored at 0.                      |

## How to Run the Tests

1. Ensure you have the .NET SDK installed on your system.
    - [Download .NET](https://dotnet.microsoft.com/download)

2. Clone the repository or place the test files in the project folder.

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Run the tests:
   ```bash
   dotnet test
   ```

5. Review the test results to ensure all tests pass.

## File Structure

- **`GildedRoseTests.cs`**: Contains the NUnit tests for the Gilded Rose Kata.
- **`GildedRose.cs`**: Main class implementing the business logic.
- **`Item.cs`**: Represents the items in the store.
- **`Program.cs`**: Entry point for manual testing.
