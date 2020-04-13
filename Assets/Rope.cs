using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {
    public GameObject linkPrefab;
    public Rigidbody2D startAnchor, endAnchor;
    public Transform anch;
    public int linksCount = 7;

    private LineRenderer lineRenderer;
    private List<GameObject> segments = new List<GameObject>();

    private void GenerateRope() {
        segments.Add(startAnchor.gameObject);
        Rigidbody2D parent = startAnchor;
        for (int i = 0; i < linksCount; ++i) {
            GameObject link = Instantiate(linkPrefab, transform);
            link.transform.position = startAnchor.position + i * new Vector2(0, -.475f);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = parent;

            segments.Add(link);
            parent = link.GetComponent<Rigidbody2D>();
        }

        if (endAnchor) {
            HingeJoint2D lastLink = endAnchor.gameObject.AddComponent<HingeJoint2D>();
            lastLink.connectedBody = parent;
            lastLink.autoConfigureConnectedAnchor = false;
            lastLink.anchor = anch.localPosition;
            lastLink.connectedAnchor = new Vector2(0f, -0.3f);
            segments.Add(anch.gameObject);
        }
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
