<template>
  <div id="creatteam-container">
    <el-container>
      <el-main>
        <el-breadcrumb separator-class="el-icon-arrow-right">
          <el-breadcrumb-item :to="{ path: '/users/UserPage' }">首页</el-breadcrumb-item>
          <el-breadcrumb-item>个人信息</el-breadcrumb-item>
        </el-breadcrumb>
        <el-descriptions class="margin-top" title=" " :column="3" :size="size" border>
          <template slot="extra">
          </template>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-user"></i>
              用户名
            </template>
            {{ username }}
          </el-descriptions-item>
          <!-- <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-postcard"></i>
              昵称
            </template>
            111
          </el-descriptions-item> -->
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-s-custom"></i>
              性别
            </template>
            {{gender}}
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-mobile-phone"></i>
              联系方式
            </template>
            {{ contact_info }}
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-location-outline"></i>
              就读院校
            </template>
            {{institution}}
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-office-building"></i>
              专业
            </template>
            {{major}}
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-reading"></i>
              年级
            </template>
            {{grade}}
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-coin"></i>
              积分
            </template>
            {{point}}
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-date"></i>
              注册时间
            </template>
            {{register_time}}
          </el-descriptions-item>
          <el-descriptions-item>
            <template slot="label">
              <i class="el-icon-tickets"></i>
              个人简介
            </template>
            {{introduction}}
          </el-descriptions-item>
        </el-descriptions>
      </el-main>
    </el-container>
  </div>
</template>

<script>
import global_msg from '../../utils/global.js'
import { GetUserInfor } from '@/api/MyInfor.js'
export default {
  name: 'UserInformation',
  data() {
    return {
      username: global_msg.nowuserid,
      gender:'',
      contact_info:'',
      institution:'',
      major:'',
      grade:'',
      point:'',
      register_time:'',
      introduction:'',
    };
  },
  mounted() {
    this.getlist() //页面一进入就加载表格
  },
  methods: {
    getlist() {
      let vm=this;
      let params = {
        user_id: this.username,
      };
      GetUserInfor(params).then(res=> {
        let item = res.data[0];
        vm.gender=item.gender;
        vm.contact_info=item.contact_info;
        vm.institution=item.institution;
        vm.major=item.major;
        vm.grade=item.grade;
        vm.point=item.point;
        vm.register_time=item.register_time.replace("\"", "").replace("\"", "");
        vm.introduction=item.introduction;
      })
    }
  }
}
</script>

<style>
#creatteam-container {
  position: relative;
  margin: 10px 0;
  margin-left: 0px;
  height: 100%;
}

.el-aside {
  color: #333;
}
</style>