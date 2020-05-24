namespace Program
{
    class DNode<T>
    {

        /// <summary>
        /// Указатель на следующий эл.
        /// </summary>
        DNode<T> next = null;
        /// <summary>
        /// Указатель на предыдущий эл.
        /// </summary>
        DNode<T> early = null;

        /// <summary>
        /// Создать узел указывающий сам на себя с обеих сторон.
        /// </summary>
        public DNode(T data)
        {
            next = this;
            early = this;
            Data = data;
        }

        /// <summary>
        /// Данные узла.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Вставить элемент в следущий.
        /// </summary>
        public void InsertNext(ref DNode<T> item)
        {
            next = item;
            item.early = this;
        }

        /// <summary>
        /// Вставить элемент в предыдущий.
        /// </summary>
        public void InsertEarly(ref DNode<T> item)
        {
            early = item;
            item.next = this;
        }

        /// <summary>
        /// Удалить текущий эл. из связки.
        /// </summary>
        public void Delete()
        {
            early.next = next;
            next.early = early;
            next = null;
            early = null;

        }

        /// <summary>
        /// Получить след. эл.
        /// </summary>
        public ref DNode<T> NextNode => ref next;

        /// <summary>
        /// Получить пред. эл.
        /// </summary>
        public ref DNode<T> EarlyNode => ref early;
    }
}
