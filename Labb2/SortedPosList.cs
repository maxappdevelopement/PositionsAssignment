using System;
using System.IO;
using System.Collections.Generic;

namespace Labb2
{
    public class SortedPosList
    {
        private List<Position> positions = new List<Position>();
        private PersistanceHandler persistanceHandler;

        public SortedPosList() { }

        public SortedPosList(string filePath)
        {
            persistanceHandler = new PersistanceHandler(filePath);
            positions = persistanceHandler.LoadPositions();
        }

        private int Count()
        {
            return positions.Count;
        }

        public void Add(Position p)
        {
            positions.Insert(0, p);

            for (int i = 0; i < Count() - 1; i++)
            {
                if (positions[i] > positions[i + 1])
                {
                    var temp = positions[i + 1];
                    positions[i + 1] = positions[i];
                    positions[i] = temp;
                }
            }

            if (persistanceHandler != null)
            {
                persistanceHandler.SavePositions(positions);
            }
        }

        public bool Remove(Position p)
        {
            int index = positions.FindIndex(x => x.Equals(p));

            if (index >= 0)
            {
                positions.RemoveAt(index);
                return true;
            }
            return false;
        }

        public SortedPosList SortedPosListClone()
        {
            SortedPosList clone = new SortedPosList();
            for (int i = 0; i < Count(); i++)
            {
                clone.positions.Insert(i, positions[i].Clone());
            }
            return clone;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList clone = SortedPosListClone();
            for (int i = 0; i < clone.Count(); i++)
            {
                if (centerPos % clone.positions[i] > radius)
                {
                    clone.Remove(clone.positions[i]);
                    i--;
                }
            }
            return clone;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList clone = sp1.SortedPosListClone();
            foreach (var position in sp2.positions)
            {
                clone.Add(position);
            }
            return clone;
        }

    
        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList clone = sp1.SortedPosListClone();

            int i = 0, j = 0;
            while (i < sp1.Count() && j < sp2.Count())
            {
                if (sp1.positions[i].Equals(sp2.positions[j]))
                {
                    clone.Remove(sp1.positions[i]);
                    i++;
                    j++;
                }
                else if (sp1.positions[i] < sp2.positions[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return clone;
        }

        public Position this[int key]
        {
            get => positions[key];
        }

        public override string ToString()
        {
            return string.Join(",", positions);
        }
    }
}






