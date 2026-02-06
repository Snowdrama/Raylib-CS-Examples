using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaylibCSExamples;

internal interface IRaylibScene
{
    void Init();
    void Input();
    void Update();
    void Draw();
}
