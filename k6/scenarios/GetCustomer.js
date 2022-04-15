import http from 'k6/http'
import { Trend, Rate, Counter } from 'k6/metrics'
import { sleep } from 'k6'
import { check, fail } from 'k6'

export let GetCustomerDuration = new Trend('get_customer_duration')
export let GetCustomerFailRate = new Rate('get_customer_fail_rate')
export let GetCustomerSucessRate = new Rate('get_customer_sucess_rate')
export let GetCustomerSucessReqs = new Counter('get_customer_success_rate')

export default function(){
    let response = http.get('http://localhost:8080/api/user/listAll')

    GetCustomerDuration.add(response.timings.duration)
    GetCustomerSucessReqs.add(1)
    GetCustomerFailRate.add(response.status == 0 || response.status > 399)
    GetCustomerSucessRate.add(response.status !== 0 && response.status < 399)

    let durationMsg = 'Máximo de duração da minha reaquisição 5s'

    if(!check(response,{
        'máximo de duração' : (r) => r.timings.duration < 5000,
    })){
        fail(durationMsg)
    }
    sleep(1)
}