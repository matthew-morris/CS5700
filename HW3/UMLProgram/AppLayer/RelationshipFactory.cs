using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public class RelationshipFactory
    {
        public Relationship createRelationship(String type, Point p1, Point p2, bool _isDotted)
        {
            Relationship relationship = null;

            if (type.Equals("Aggregation"))
            {
                relationship = new Aggregation(p1, p2, _isDotted);
            }
            else if (type.Equals("BinaryAssocation"))
            {
                relationship = new BinaryAssocation(p1, p2, _isDotted);
            }
            else if (type.Equals("Composition"))
            {
                relationship = new Composition(p1, p2, _isDotted);
            }
            else if (type.Equals("Dependency"))
            {
                relationship = new Dependency(p1, p2, _isDotted);
            }
            else if (type.Equals("Generalization"))
            {
                relationship = new Generalization(p1, p2, _isDotted);
            }

            return relationship;
        }
    }
}
