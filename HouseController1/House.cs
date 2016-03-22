using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	class House
	{
		Room entryRoom;
		Sector livingRoom;
		Sector kitchen;
		Sector diningRoom;
		Room office;
		Sector hallway;
		Room bennyRoom;
		Room bathRoom;
		Room parentRoom;
		Room mateoRoom;

		public House()
		{
			Initialize();
		}

		private void Initialize()
		{
			entryRoom = new Room(new Door(true), new Window[0] { });
			livingRoom = new Sector(new Window[4] { new Window(), new Window(), new Window(), new Window() });
			kitchen = new Sector(new Window[2] { new Window(), new Window() });
			diningRoom = new Sector(new Window[1] { new Window() });
			office = new Room(new Door(false), new Window[1] { new Window() });
			hallway = new Sector(new Window[0] { });
			bennyRoom = new Room(new Door(true), new Window[1] { new Window() });
			bathRoom = new Room(new Door(true), new Window[1] { new Window() });
			parentRoom = new Room(new Door(true), new Window[2] { new Window(), new Window() });
			mateoRoom = new Room(new Door(true), new Window[2] { new Window(), new Window() });
		}
	}
}
