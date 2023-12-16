using SpaceCircle.App.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCircle.App.Game.Managers;

public class ConnectionManager : Entity
{
    public List<(Guid p1, Guid p2)> Connections = new(); //LATER:this tuple is kinda gross
    public List<LineComponent> ActiveConnections = new();
    public static ConnectionManager Instance;

    public ConnectionManager() 
    {
        Instance = this;
        Instance.AddPlanetConnection += AddConnection;
        RegisterEntity(this);
    }

    public event Action<Guid, Guid> AddPlanetConnection;
    public void onAddPlanetConnection(Guid p1, Guid p2)
    {
        AddPlanetConnection?.Invoke(p1, p2);
    }

    public override void Update(float deltaTime)
    {
        ResetConnections();
        SetActiveConnections();
    }

    public override void Destroy()
    {
        Instance.AddPlanetConnection -= AddConnection;
        ResetConnections();
    }

    private void AddConnection(Guid p1, Guid p2)
    {
        Connections.Add((p1, p2));
    }

    private void ResetConnections() 
    {
        foreach (var comp in ActiveConnections) 
            DrawableSystem.Unregister(comp);

        ActiveConnections.Clear();


    }

    public void SetActiveConnections() 
    {
        foreach (var conn in Connections)
        {
            var t1 = SystemBase.GetEntity(conn.p1);
            var t2 = SystemBase.GetEntity(conn.p2);

            if (t1 == null || t2 == null)
                continue;

            var t1_pos = t1.GetComponent<Transform2D>().Position;
            var t1_details = t1.GetComponent<PlanetDetailsComponent>().PlanetStruct;
            var t2_pos = t2.GetComponent<Transform2D>().Position;
            var t2_details = t2.GetComponent<PlanetDetailsComponent>().PlanetStruct;

            bool inRange = CheckCollisionCircles(t1_pos, 300f, t2_pos, t2_details.Diameter / 2);

            if (inRange)
            {
                var line = new LineComponent() { StartPos = t1_pos, EndPos = t2_pos};
                AddComponent(line);
                ActiveConnections.Add(line);
            }

        }
    }
}
