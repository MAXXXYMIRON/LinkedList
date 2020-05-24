using System;

namespace Program
{
    class DList<T>
    {
        /// <summary>
        /// Голова и хвост списка соответственно.
        /// </summary>
        DNode<T> head = null, 
            tail = null;

        /// <summary>
        /// Переменные необходимые координации по списку.
        /// </summary>
        DNode<T> temp, 
            node;


        /// <summary>
        /// Для создания списка нужно поместить в него хотя бы один элемент.
        /// </summary>
        /// <param name="data">Данные которые необходимо записать.</param>
        public DList(T data)
        {
            head = new DNode<T>(data);
            tail = head;

            Size++;
        }



        /// <summary>
        /// Получить текущий размер списка.
        /// </summary>
        public int Size { get; private set; } = 0;

        /// <summary>
        /// Задать или получить данные по индексу.
        /// </summary>
        public T this[int index]
        {
            get
            {
                ListIsReady();
                IndexInList(index);

                temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.NextNode;
                }
                return temp.Data;
            }
            set
            {
                ListIsReady();
                IndexInList(index);

                temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.NextNode;
                }
                temp.Data = value;
            }
        }

        /// <summary>
        /// Проверить, является ли список начальным, т.е. содержащем один элемент.
        /// </summary>
        public bool IsOrigin => (Size == 1);



        /// <summary>
        /// Добаыить элемент в позицию в списке.
        /// </summary>
        public void Add(int index, T item)
        {
            ListIsReady();
            IndexInList(index);

            //Добавить в голову.
            if(index == 0)
            {
                temp = head;
                head = new DNode<T>(item);
                head.InsertNext(ref temp);
                head.InsertEarly(ref tail);
            }
            //Добавить в хвост.
            else if(index == Size - 1)
            {
                temp = tail;
                tail = new DNode<T>(item);
                tail.InsertNext(ref head);
                tail.InsertEarly(ref temp);
            }
            //Добавить в любое место.
            else
            {
                node = new DNode<T>(item);
                temp = head.NextNode;
                for (int i = 1; i < index; i++)
                {
                    temp = temp.NextNode;
                }
                temp.EarlyNode.InsertNext(ref node);
                temp.InsertEarly(ref node);
            }
            Size++;
        }

        /// <summary>
        /// Удалить элементы из позиций indexes.
        /// При удалении элемента происходит сдвиг остальных по индексам,
        /// так что передавать идексы стоит в порядке убывания(от дальнего к ближнему).
        /// </summary>
        public void Del(params int[] indexes)
        {
            //Проход по массиву индексов в которых нужно удалить элементы.
            foreach (var item in indexes)
            {
                ListIsReady();
                IndexInList(item);
                if (IsOrigin) throw new Exception("В списке должен на ходится хотя бы один эл.");

                //Удалить из головы.
                if (item == 0)
                {
                    temp = head;
                    head = head.NextNode;
                    temp.Delete();
                }
                //Удалить из хвоста.
                else if (item == Size - 1)
                {
                    temp = tail;
                    tail = tail.EarlyNode;
                    temp.Delete();
                }
                //Удалить из любой позиции.
                else
                {
                    temp = head.NextNode;
                    for (int i = 1; i < item; i++)
                    {
                        temp = temp.NextNode;
                    }
                    temp.Delete();
                }
                temp = null;

                Size--; 
            }
        }

        /// <summary>
        /// Проверить создан ли список.
        /// </summary>
        private void ListIsReady()
        {
            if (head == null) throw new Exception("Список не инициализирован!");
        }

        /// <summary>
        /// Проверить является ли индекс достижимым для текущего состояния списка.
        /// </summary>
        private void IndexInList(int index)
        {
            if (index < 0 || index >= Size) throw new Exception("Индекс вне границ списка!");
        }

    }
}
