/* Disclaimer: The examples and comments from this program are from
   C#7 in a Nutshell and are written for learning purposes only. */
   // CODE DOES NOT COMPILE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Initializers_Vs_Opt_Parameters
{


    class Program
    {
        /* Instead of using object parameters, we could make Bunny's
          constructor accept optional parameters: */
        public void Bunny(string name,
                  bool likesCarrots = false,
                  bool likesHumans = false)
        {
            Name = name;
            LikesCarrots = likesCarrots;
            LikesHumans = likesHumans;
        }
        static void Main()
        {
            //This would allow us to construct a Bunny as follows:
            Bunny b1 = new Bunny(name: "Bo",
                                  likesCarrots: true);
            /* An advantage to this approach is that we could make Bunny's fields
             (or properties) read-only if we choose. Making fields or properties 
             read-only is good practice when there's not valid reason forthem to
             change throughout the life of the object. 
             
             The disadvantage in this approach is that each optional parameter is
             baked into the calling site. In other words, C# translates our 
             constructor call into this: */
            Bunny b1 = new Bunny("Bo", true, false);
            /* This can be problematic if we instantiate the Bunny class from
             another assembly, and later modify Bunny by adding another 
             optional parameter-such as likesCats. Unless the referencing 
             assembly is also recompiled, it will continue to call the (now
             nonexistent) constructor with three parameters and fail at 
             runtime. (A subtler problem is that if we changed the value 
             of one of the optional parameters, callers in other assemblies
             would continue to use the old optional value until they were
             recompiled.)
             
             Hence, you should excercise caution with optional parameters in
             public functions if you want to offer compatibility between
             assembly versions. */

        }
    }
}
