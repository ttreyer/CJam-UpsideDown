using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {
    public GameObject linkPrefab;

    public Rigidbody2D startObject ;
    public Transform startAnchor;

    public Rigidbody2D endObject;
    public Transform endAnchor;

    public int linksCount = 7;

    private LineRenderer lineRenderer;
    private List<GameObject> segments = new List<GameObject>();

    private void GenerateRope() {
        Rigidbody2D parent = startObject;
        segments.Add(parent.gameObject);

        if (linksCount > 1) {
            for (int i = 0; i < linksCount - 1; ++i) {
                GameObject link = Instantiate(linkPrefab, transform);
                link.transform.position = parent.position + new Vector2(0, -.475f);
                HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
                joint.connectedBody = parent;

                segments.Add(link);
                parent = link.GetComponent<Rigidbody2D>();
            }
        }

        HingeJoint2D lastLink = endObject.gameObject.AddComponent<HingeJoint2D>();
        lastLink.connectedBody = parent;
        lastLink.autoConfigureConnectedAnchor = false;
        lastLink.anchor = endAnchor.localPosition;
        lastLink.connectedAnchor = new Vector2(0f, -0.3f);
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
