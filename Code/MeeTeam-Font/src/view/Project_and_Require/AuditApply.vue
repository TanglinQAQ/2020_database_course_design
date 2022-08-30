<template>
  <div class="detaildiv">
    <el-main>
      <div id="breadcrumb">
        <el-breadcrumb separator-class="el-icon-arrow-right">
          <el-breadcrumb-item :to="{ path: '/users/UserPage' }">首页</el-breadcrumb-item>
          <el-breadcrumb-item>项目管理</el-breadcrumb-item>
          <el-breadcrumb-item>我的项目</el-breadcrumb-item>
          <el-breadcrumb-item>审核申请</el-breadcrumb-item>
        </el-breadcrumb>
      </div>
      <p class="title" align="center" label="项目名称">{{  project_name  }}</p>
      <p align="left"><strong>申请人列表</strong></p>
      <el-table :data="tableData" :header-cell-style="{ textAlign: 'center' }"
          :cell-style="{ 'text-align': 'center' }" default-sort="{ prop: 'date', order: 'descending' }">
          <el-table-column prop="applicant_id" label="申请人id" width="200">
          </el-table-column>
          <el-table-column label="操作">
            <template slot-scope="scope">
              <el-button size="mini" @click="handlecheck(scope.$index, scope.row)">查看申请人主页</el-button>
              <el-button size="mini" type="success" @click="agree(scope.$index, scope.row)">同意</el-button>
              <el-button size="mini" type="danger" @click="agree(scope.$index, scope.row)">拒绝</el-button>
            </template>
          </el-table-column>
        </el-table>
    </el-main>
  </div>
</template>

<script>
import global_msg from '../../utils/global.js'
import { get_apply } from '@/api/ProjectDetail.js'
export default {
  name: 'MyProject',
  data() {
    return {
      username: global_msg.nowuserid,
      tableData: [],
    };
  },
  mounted() {
    this.getlist() //页面一进入就加载表格
  },
  methods: {
    goback() {
      this.$router.push({ path: "/users/InforList" }); //返回
    },
    getlist() {
      var vm = this;//全局变量
      let para = {
            pid: vm.$route.query.p_id,
            duty: "申请者"
      };
      get_apply(para).then(function (res) {
        for (let item of res.data) {
          let form = {//设置添加数据的格式
            applicant_id: '',
          }
          //发布表
          form.applicant_id = item.applicant_id;
          vm.tableData.push(form);
        }
      })
    },
  }
}
</script>

<style>
#breadcrumb {
  margin-bottom: 10px;
}

.myproject-container {
  position: absolute;
  margin-left: 0px;
  height: 100%;
  bottom: 0%;
  right: 0px;
  left: 0px;
}

.el-header {
  background-color: #B3C0D1;
  color: #333;
  line-height: 55px;
  font-weight: 900;
  font-style: normal;
}

.item {
  margin-top: 0px;
  margin-right: 10px;
}

.container {
  display: inline;
  float: left;
  display: inline-block;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 48px;
}
</style>