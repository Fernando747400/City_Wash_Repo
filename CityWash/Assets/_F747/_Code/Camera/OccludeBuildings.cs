using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccludeBuildings : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Material _transparentMaterial;
    [SerializeField] private GameObject _player;
    [SerializeField] private LayerMask _layerMask;

    private Vector3 _direction;
    private float _distance;
    private Queue<GameObject> _buildings = new Queue<GameObject>();

    private void Start()
    {
        UpdatePos();
        _distance = Vector3.Distance(this.transform.position, _player.transform.position);       
    }


    private void Update()
    {
        UpdatePos();
        SendRay();
    }

    private void SendRay()
    {
        RaycastHit hit;
        //Debug.DrawRay(this.transform.position, this.gameObject.transform.forward * 40f, Color.green, Time.deltaTime, false);
        if (Physics.Raycast(this.transform.position,_direction,out hit ,_distance, _layerMask.value))
        {
            if(_buildings.Count != 0)
            {
                if (hit.collider.gameObject != _buildings.Peek())
                {
                    ChangeToTransparent(hit.collider.gameObject);
                    _buildings.Enqueue(hit.collider.gameObject);
                    ChangeToNormal(_buildings.Peek());
                    _buildings.Dequeue();
                }
            }else
            {
                ChangeToTransparent(hit.collider.gameObject);
                _buildings.Enqueue(hit.collider.gameObject);
            }                                      
        }
        else if (_buildings.Count != 0)
        {
            ChangeToNormal(_buildings.Peek());
            _buildings.Dequeue();
        }
    }

    private void ChangeToNormal(GameObject building)
    {
        building.GetComponent<Renderer>().material = _normalMaterial;
    }

    private void ChangeToTransparent(GameObject building)
    {
        building.GetComponent<Renderer>().material = _transparentMaterial;
    }

    private void UpdatePos()
    {
        _direction =_player.transform.position - this.transform.position;
        _direction.Normalize();

        //Debug.DrawRay(this.transform.position, _direction * 40f, Color.red, Time.deltaTime, false);
    }

}
