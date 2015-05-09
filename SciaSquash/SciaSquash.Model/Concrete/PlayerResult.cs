using System;
using System.Collections.Generic;
using System.Linq;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Entities;

namespace SciaSquash.Model.Concrete
{
    public class PlayerResult : IPlayerResult
    {
        public PlayerResult()
        {
            m_scorePlus = 0;
            m_scoreMinus = 0;
            m_rivalScore = new Dictionary<int, IScore4Rival>();
        }

        #region MEMBERS
        int m_scorePlus;
        int m_scoreMinus;
        Player m_player;
        readonly Dictionary<int, IScore4Rival> m_rivalScore;
        #endregion

        #region PROPERTIES
        public Dictionary<int, IScore4Rival> RivalScore
        {
            get { return m_rivalScore; }
        }
        public Player Player
        {
            get { return m_player; }
            set 
            { 
                m_player = value;
                UpdateScoreMinus();
                UpdateScorePlus();
            }
        }
        public int Points
        {
            get 
            {
                int retVal = 0;
                foreach (var item in m_rivalScore.Values)
                {
                    retVal += item.Points;
                }
                return retVal;
            }
        }
        public int ScoreMinus
        {
            get
            {
                if (m_scoreMinus <= 0)
                {
                    UpdateScoreMinus();
                }
                return m_scoreMinus;
            }
            set { m_scoreMinus = value; }
        }
        public int ScrorePlus
        {
            get
            {
                if (m_scorePlus <= 0)
                {
                    UpdateScorePlus();
                }
                return m_scorePlus;
            }
            set { m_scorePlus = value; }
        }
        #endregion



        #region METHODS
        private void UpdateScorePlus()
        {
            m_scorePlus = 0;
            if (Player == null)
            {
                return;
            }
            foreach (var matchPlayerAsFirst in Player.PlayerAsFirst)
            {
                m_scorePlus += matchPlayerAsFirst.ScorePlayerFirst;
            }
            foreach (var matchPlayerAsFirst in Player.PlayerAsSecond)
            {
                m_scorePlus += matchPlayerAsFirst.ScorePlayerSecond;
            }
        }
        private void UpdateScoreMinus()
        {
            m_scoreMinus = 0;
            if (Player == null)
            {
                return;
            }
            foreach (var matchPlayerAsFirst in Player.PlayerAsFirst)
            {
                m_scoreMinus += matchPlayerAsFirst.ScorePlayerSecond;
            }
            foreach (var matchPlayerAsFirst in Player.PlayerAsSecond)
            {
                m_scoreMinus += matchPlayerAsFirst.ScorePlayerFirst;
            }
        }
        #endregion
    }
}
