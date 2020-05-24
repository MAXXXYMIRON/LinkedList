using System;

namespace Program
{
    class LinkedQueue<T>
    {
        DList<T> dList;

        /// <summary>
        /// Длина связанной очереди.
        /// </summary>
        public readonly int Length;

        /// <summary>
        /// Конструктор задает размер очереди и выделяет доп. память 
        /// в сборщике мусора.
        /// sizeType - размер переменной, хранящейся в очереди.
        /// count - количество элементов очереди (по умолчанию 50).
        /// </summary>
        public LinkedQueue(int sizeType, int count = 50)
        {
            //Выделить память для сборщика мусора. 
            GC.AddMemoryPressure(count * sizeType);
            Length = count;
        }



        /// <summary>
        /// Вернуть элемент связной очереди без его удаления из очереди.
        /// </summary>
        public T Peek
        {
            get
            {
                if (dList is null || dList.IsOrigin) throw new Exception("Очередь пуста.");
                return dList[1];
            }
        }

        /// <summary>
        /// Вернуть элемент из начала связной очереди и удалить его из списка.
        /// </summary>
        public T Dqueue
        {
            get
            {
                if (dList is null || dList.IsOrigin) throw new Exception("Очередь пуста.");
                T item = dList[1];
                dList.Del(1);

                return item;
            }
        }

        /// <summary>
        /// Поместить элемент в связную очередь.
        /// </summary>
        public T Enqueue
        {
            set
            {
                if (dList is null) dList = new DList<T>(value);
                if (Count > Length) throw new Exception("Очередь полна.");

                dList.Add(Count - 1, value);
            }
        }


        /// <summary>
        /// Очистить очередь.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                dList.Del(0);
            }
        }


        /// <summary>
        /// Кол-во элементов в связанной очереди. 
        /// </summary>
        public int Count => dList.Size;

        /// <summary>
        /// Проверить пуста ли связаная очередь. 
        /// </summary>
        public bool IsEmpty => (dList.Size == 1);

        /// <summary>
        /// Проверить полна связаная очередь. 
        /// </summary>
        public bool IsFull => (dList.Size - 1 == Length);
    }
}
