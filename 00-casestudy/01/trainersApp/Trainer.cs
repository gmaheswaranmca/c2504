using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject
{
    internal class Trainer
    {
        public int id;
        public string name;
        public string skill;
        public string place;

        public Trainer(int _id, string _name, string _skill, string _place)
        {
            id = _id;
            name = _name;
            skill = _skill;
            place = _place;
        }

        public override string ToString()
        {
            return $"[id={id},name={name},skill={skill},place={place}]";
        }
    }
}
