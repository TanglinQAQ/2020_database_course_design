import request from '@/utils/request'

  export function getlistInfor() {
    /*组队需求的表格*/
    return request({
      url: '/Project/SelectAllProject',
      method: 'get',
    })
  }