import request from '@/utils/request'

  export function PullInfo(params) {
    /*创建组队需求 */
    return request({
      url: '/Info/PullInfo',
      method: 'get',
      params:{
        ID:params.ID,
        gender:params.gender,
        phone_number:params.phone_number,
        institution:params.institution,
        major:params.major,
        introduction:params.introduction,
      }
    })
  }