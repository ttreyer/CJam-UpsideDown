using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {
    public GameObject linkPrefab;

    public Rigidbody2D startObject ;
    public Transform startAnchor;

    public Rigidbody2D endObject;
    public Transform endAnchor;

    public float linkLength = 0.25f;

    private LineRenderer lineRenderer;
    private List<GameObject> segments = new List<GameObject>();

    private void GenerateRope() {
        Vector2 startToEnd = endAnchor.position - startAnchor.position;
        Vector2 linkVec = -startToEnd.normalized * linkLength;
        int linksCount = Mathf.FloorToInt(startToEnd.magnitude / linkLength);

        Rigidbody2D parent = startObject;
        segments.Add(parent.gameObject);

        if (linksCount > 1) {
            for (int i = 0; i < linksCount; ++i) {
                GameObject link = Instantiate(linkPrefab, transform);
                link.transform.position = parent.position + linkVec;

                HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
                joint.anchor = linkVec;
                joint.connectedAnchor = Vector2.zero;
                joint.connectedBody = parent;

                segments.Add(link);
                parent = link.GetComponent<Rigidbody2D>();
            }
        }

        HingeJoint2D lastLink = endObject.gameObject.AddComponent<HingeJoint2D>();
        lastLink.connectedBody = parent;
        lastLink.autoConfigureConnectedAnchor = false;
        lastLink.anchor = endAnchor.localPosition;
        lastLink.connectedAnchor = Vector2.zero;
        segments.Add(endAnchor.gameObject);
    }

    private void DrawRope() {
        Vector3[] ropePositions = new Vector3[segments.Count];
        for (int i = 0, c = segments.Count; i < c; ++i)
            ropePositions[i] = segments[i].transform.position;

        lineRenderer.positionCount = segments.Count;
        lineRenderer.SetPositions(ropePositions);
    }

    // Start is called before the first frame update
    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        GenerateRope();
    }

    // Update is called once per frame
    void Update() {
        DrawRope();
    }
}
