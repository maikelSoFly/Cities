using System;

namespace Cities_console {
    public class Region {
        
        private String name;
        private int uid;

        public Region(String name, int uid) {
            this.name = name;
            this.uid = uid;
        }

        //MARK: - Getters.
        public int getUID() {
            return uid;
        }

        public String getName()
        {
            return name;
        }
    }
}
