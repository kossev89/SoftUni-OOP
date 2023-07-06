int[] numbers = new int[10];

for (int i = 0; i < numbers.Length; i++)
{
    if (i==0)
    {
        numbers[i] = ReadNumber(1, 100);
    }
    else
    {
        numbers[i] = ReadNumber(numbers[i - 1], 100);
    }

}

Console.WriteLine(String.Join(", ", numbers));



static int ReadNumber(int start, int end)
{
    int number = default;
    bool isValid = false;
    while (isValid == false)
    {
        try
        {
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number <= start
                    || number >= end
                    )
                {
                    throw new ArgumentException($"Your number is not in range {start} - {end}!");
                }
                else
                {
                    isValid = true;
                }
            }
            else
            {
                throw new ArgumentException("Invalid Number!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
    return number;
}
