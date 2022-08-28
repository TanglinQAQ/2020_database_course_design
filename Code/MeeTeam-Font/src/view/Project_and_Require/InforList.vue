<template>
  <el-main>
    <div id="breadcrumb">
      <el-breadcrumb separator-class="el-icon-arrow-right">
        <el-breadcrumb-item :to="{ path: '/users/UserPage' }">首页</el-breadcrumb-item>
        <el-breadcrumb-item>项目管理</el-breadcrumb-item>
        <el-breadcrumb-item>平台项目列表</el-breadcrumb-item>
      </el-breadcrumb>
    </div>
    <div style="height: 50px;">
      <el-autocomplete class="inline-input" v-model="state1" :fetch-suggestions="querySearch" placeholder="项目名称"
        @select="handleSelect" style="float:left;margin-right:30px;width:150px;"></el-autocomplete>
      <el-autocomplete class="inline-input" v-model="state1" :fetch-suggestions="querySearch" placeholder="项目发布人"
        @select="handleSelect" style="float:left;margin-right:30px;width:150px;"></el-autocomplete>
      <el-select v-model="value2" multiple placeholder="项目当前进度" style="float:left;margin-right:30px;width:150px;">
        <el-option v-for="item in options3" :key="item.value" :label="item.label" :value="item.value">
        </el-option>
      </el-select>
      <el-select v-model="value2" multiple placeholder="是否有组队需求" style="float:left;margin-right:30px;width:150px;">
        <el-option v-for="item in options3" :key="item.value" :label="item.label" :value="item.value">
        </el-option>
      </el-select>
      <el-button class="filter-item" type="primary" icon="el-icon-search" @click="searchContList" style="float:left">
        搜索
      </el-button>
    </div>
    <br>
    <div>
      <el-table :data="tableData" :header-cell-style="{ textAlign: 'center' }" :cell-style="{ 'text-align': 'center' }"
        default-sort="{ prop: 'create_time', order: 'descending' }">
        <el-table-column prop="project_name" label="项目名称" width="150">
        </el-table-column>
        <el-table-column prop="project_introduction" label="项目简介" width="350">
        </el-table-column>
        <el-table-column prop="project_progress" label="项目当前进度" width="150">
        </el-table-column>
        <el-table-column prop="create_time" label="发布时间" sortable width="150">
        </el-table-column>
        <el-table-column prop="project_status" label="是否有组队需求" width="150">
        </el-table-column>
        <el-table-column label="操作">
          <template slot-scope="scope">
            <el-button size="mini" @click="handleLook(scope.$index, scope.row)">查看详情</el-button>
          </template>
        </el-table-column>
      </el-table>
    </div>
  </el-main>
</template>

<script>
import global_msg from '../../utils/global.js'
import { getlistInfor } from '@/api/Inforlist.js'
import { getrequireInfor } from '@/api/Inforlist.js'
export default {
  name: 'InforList',
  data() {
    return {
      activeName: "项目列表",
      username: global_msg.nowuserid,
      tableData: [],
    };
  },
  mounted() {
    this.getlist() //页面一进入就加载表格
  },
  methods: {
    handleLook(index, row) {//进入项目详情页面
      var project_id = this.tableData[index].project_id;
      console.log(index, row);
      this.$router.push({ path: "/users/ProjectDetail", query: { p_id: project_id } });
    },
    handleClick(tab, event) {
      console.log(tab, event);
    },
    additem: function () {
      this.$router.push({ path: "/users/CreatList" }); //接下来进入到CreatList
    },
    myitem: function () {
      this.$router.push({ path: "/users/MyProject" }); //接下来进入到MyProject
    },
    getlist() {
      var vm = this;//全局变量
      getrequireInfor().then(function (res1) {
        global_msg.requirenum = res1.data.length;//改变全局projectnum
      })
      getlistInfor().then(function (res) {
        global_msg.projectnum = res.data.length;//改变全局requirenum
        // console.log(res);
        // console.log(res.data.length);
        // console.log(res.data[0]);
        // console.log(res.data[0].details);
        for (let item of res.data) {
          let form = {//设置添加数据的格式
            project_name: '',
            project_introduction: '',
            project_progress: '',
            create_time: '',
            project_status: '',
            project_id: '',
          }

          form.project_name = item.project_name;
          form.project_introduction = item.project_introduction;
          form.project_progress = item.project_progress;
          form.create_time = item.create_time;
          form.create_time = form.create_time.replace("\"", "").replace("\"", "");//去掉时间格式的引号
          form.project_status = item.project_status;
          form.project_id = item.project_id;

          vm.tableData.push(form);
          // console.log(form);
          // console.log(vm.tableData);
        }
      })
    }
  }
}
</script>

<style scoped>
#breadcrumb {
  margin-bottom: 10px;
}

</style>