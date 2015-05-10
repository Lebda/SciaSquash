using System;
using System.Linq;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Concrete
{
    internal class Score4Rival : IScore4Rival
    {
        public Score4Rival()
        {
            m_scoreMinus = 0;
            m_scorePlus = 0;
        }

        #region MEMBERS
        int m_scorePlus;
        int m_scoreMinus;
        #endregion

        #region PROPERTIES
        public Player Rival { get; set; }
        public int Points
        {
            get { return GetPoints(); }
        }
        public int ScoreMinus
        {
            get { return m_scoreMinus; }
            set 
            { 
                m_scoreMinus = value;
            }
        }
        public int ScorePlus
        {
            get { return m_scorePlus; }
            set 
            { 
                m_scorePlus = value;
            }
        }
        #endregion

        #region METHODS
        private int GetPoints()
        {
            if (m_scorePlus > m_scoreMinus)
            {
                return 2;
            }
            else if (m_scorePlus == m_scoreMinus)
            {
                return 1;
            }
            return 0;
        }
        #endregion
    }
}
