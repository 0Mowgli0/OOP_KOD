using System;

namespace OOP_KOD
{
    internal class MapViewer
    {
        private readonly EventPicker _picker;
        private readonly EventManager _manager;

        public MapViewer(EventPicker picker, EventManager manager)
        {
            _picker = picker;
            _manager = manager;
        }

        public void ShowMap()
        {
            var ev = _picker.PickEvent();
            Console.WriteLine(_manager.GetSeatMap(ev));
        }
    }
}
