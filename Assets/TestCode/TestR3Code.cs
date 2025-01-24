using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R3;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.TestCode
{
    public class TestR3Code : MonoBehaviour
    {
        [SerializeField] private Button _takeDamageButton;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private float _health;

        public Observable<float> HealthEvent => _healthSubject;
        private Subject<float> _healthSubject;
        private Subject<Unit> _damageSubject;
        private CompositeDisposable cd;
        public void TakeDamage()
        {
            _damageSubject.OnNext(new Unit());
            Debug.Log("take damage.");
        }

        public void Awake()
        {
            _health = 160.0f;
            _healthSubject = new Subject<float>();
            _healthSubject.OnNext(_health);

            _damageSubject = new Subject<Unit>();
        }

        public void Start()
        {
            // in subject
            _damageSubject.Subscribe<Unit>(_ =>
            {
                _health -= 5.0f;
                _healthSubject.OnNext(_health);
            }).AddTo(cd);


            // in some ui
            HealthEvent.Subscribe<float>(value =>
            {
                _healthText.text = value.ToString();
                Debug.Log(value);
            }).AddTo(cd);
        }

        private void OnDisable()
        {
            cd.Dispose();
        }

        //private void TestReflaction1()
        //{
        //    _currentHealth.Subscribe<float>(value =>
        //    {
        //        _healthText.text = value.ToString();
        //        Debug.Log(value);
        //    });

        //    _currentHealth.OnNext(10);
        //    _currentHealth.OnNext(50);
        //    _currentHealth.OnNext(40);
        //    _currentHealth.Value += 100;
        //}

    }
}
