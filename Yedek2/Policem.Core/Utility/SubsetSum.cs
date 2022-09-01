using System;
using System.Collections.Generic;

namespace Policem.Core.Utility
{
    public class SubsetSum
    {
        public static List<int> Select(decimal target, Dictionary<int, decimal> Id_Value)
        {
            List<int> selectedRollIds = new List<int>();

            decimal sumOfAvailableRolls = 0;
            decimal qtyOfBiggest = 0;
            decimal sumOfSelectedIds = 0;
            decimal delta = 0;

            List<decimal> values = new List<decimal>();
            List<int> ids = new List<int>();

            foreach (int Id in Id_Value.Keys)
            {
                ids.Add(Id);
                values.Add(Id_Value[Id]);
            }


            List<List<decimal>> results = new List<List<decimal>>();

            for (int i = 0; i < values.Count; i++)
            {
                decimal qty = values[i];
                sumOfAvailableRolls += qty;

                if (qty > qtyOfBiggest)
                {
                    qtyOfBiggest = qty;
                }
            }

            if (target > sumOfAvailableRolls)
            {
                selectedRollIds.AddRange(ids);
                sumOfSelectedIds = sumOfAvailableRolls;
            }
            else
            {
                while (delta <= qtyOfBiggest)
                {
                    SubsetSum solver = new SubsetSum();
                    solver.delta = delta;
                    results = solver.Solve(target, values.ToArray());
                    if (results.Count > 0)
                        break;

                    delta += 1;
                }

                if (results.Count > 0)
                {
                    List<decimal> result = results[0];

                    for (int i = 0; i < result.Count; i++)
                    {
                        decimal selectedQty = result[i];
                        for (int j = 0; j < values.Count; j++)
                        {
                            decimal availableQty = values[j];
                            if (availableQty == selectedQty)
                            {
                                selectedRollIds.Add(ids[j]);
                                sumOfSelectedIds += selectedQty;
                                //Tekrar seçilmesini engellemek için miktarını sıfırla
                                values[j] = 0;
                                break;
                            }
                        }
                    }
                }
            }

            return selectedRollIds;
        }



        private List<List<decimal>> mResults;
        public long IterationCount = 0;
        public decimal delta = 1;

        public List<List<decimal>> Solve(decimal goal, decimal[] elements)
        {
            mResults = new List<List<decimal>>();
            RecursiveSolve(goal,
                0.0m,
                new List<decimal>(),
                new List<decimal>(elements),
                0);
            return mResults;
        }

        //timer ile 15 sn.'de kes ve deltayı artırmayı öner!



        bool found = false;
        private void RecursiveSolve(decimal goal, decimal currentSum, List<decimal> included, List<decimal> notIncluded, int startIndex)
        {
            if (IterationCount > 1e6)   //1e6
                return;

            for (int index = startIndex; index < notIncluded.Count; index++)
            {
                IterationCount++;
                decimal nextValue = notIncluded[index];

                if (Math.Abs(goal - (currentSum + nextValue)) < delta && !found)
                {
                    List<decimal> newResult = new List<decimal>(included);
                    newResult.Add(nextValue);   //burada RollId yi de kaydet!
                    mResults.Add(newResult);
                    found = true;
                    return;
                }
                else if (goal - (currentSum + nextValue) > 0)
                {
                    List<decimal> nextIncluded = new List<decimal>(included);
                    nextIncluded.Add(nextValue);
                    List<decimal> nextNotIncluded = new List<decimal>(notIncluded);
                    nextNotIncluded.Remove(nextValue);

                    if (!found)
                        RecursiveSolve(goal, currentSum + nextValue, nextIncluded, nextNotIncluded, startIndex++);

                }
            }
        }


    }

    
}
