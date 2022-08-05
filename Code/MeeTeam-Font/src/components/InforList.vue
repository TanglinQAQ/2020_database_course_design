<template>
  <div id="creatteam-container">
    <el-container style="height: 100%; border: 1px solid #eee">
      <el-aside width="200px" style="background-color: rgb(238, 241, 246)">
        <el-menu :default-openeds="['1', '3']">
          <el-submenu index="1">
            <template slot="title"><i class="el-icon-message"></i>组队类型</template>
            <el-submenu index="1-1">
              <template slot="title">竞赛组队</template>
              <el-menu-item index="1-1-1">创新创业</el-menu-item>
              <el-menu-item index="1-1-2">数学建模</el-menu-item>
              <el-menu-item index="1-1-3">学科竞赛</el-menu-item>
              <el-menu-item index="1-1-4">其他竞赛</el-menu-item>
            </el-submenu>
            <el-submenu index="1-2">
              <template slot="title">项目课程组队</template>
              <el-menu-item index="1-2-1">新生院</el-menu-item>
              <el-menu-item index="1-2-2">建筑与城市规划学院</el-menu-item>
              <el-menu-item index="1-2-3">土木工程学院</el-menu-item>
              <el-menu-item index="1-2-4">机械与能源工程学院</el-menu-item>
              <el-menu-item index="1-2-5">经济与管理学院</el-menu-item>
              <el-menu-item index="1-2-6">环境科学与工程学院</el-menu-item>
              <el-menu-item index="1-2-7">材料科学与工程学院</el-menu-item>
              <el-menu-item index="1-2-8">电子与信息工程学院</el-menu-item>
              <el-menu-item index="1-2-9">人文学院</el-menu-item>
              <el-menu-item index="1-2-10">外国语学院</el-menu-item>
              <el-menu-item index="1-2-11">汽车学院</el-menu-item>
              <el-menu-item index="1-2-12">软件学院</el-menu-item>
              <el-menu-item index="1-2-13">其他学院</el-menu-item>
            </el-submenu>
          </el-submenu>
          <el-submenu index="2">
            <template slot="title"><i class="el-icon-menu"></i>所在校区</template>
            <el-menu-item index="2-1">四平校区</el-menu-item>
            <el-menu-item index="2-2">嘉定校区</el-menu-item>
            <el-menu-item index="2-3">沪西校区</el-menu-item>
            <el-menu-item index="2-4">沪北校区</el-menu-item>
          </el-submenu>
          <el-submenu index="3">
            <template slot="title"><i class="el-icon-setting"></i>导航三</template>
            <el-menu-item-group>
              <template slot="title">分组一</template>
              <el-menu-item index="3-1">选项1</el-menu-item>
              <el-menu-item index="3-2">选项2</el-menu-item>
            </el-menu-item-group>
            <el-menu-item-group title="分组2">
              <el-menu-item index="3-3">选项3</el-menu-item>
            </el-menu-item-group>
            <el-submenu index="3-4">
              <template slot="title">选项4</template>
              <el-menu-item index="3-4-1">选项4-1</el-menu-item>
            </el-submenu>
          </el-submenu>
        </el-menu>
      </el-aside>
      <el-container>
        <el-header style="text-align: right; font-size: 15px; top:50%;">
          <el-button type="primary" plain @click="additem">添加项目</el-button>
          <el-button type="warning" plain @click="myitem">我的项目</el-button>
          <el-dropdown>
            <i class="el-icon-setting" style="margin: 30px"></i>
            <el-dropdown-menu slot="dropdown">
              <el-dropdown-item>用户信息</el-dropdown-item>
              <el-dropdown-item>系统设置</el-dropdown-item>
            </el-dropdown-menu>
          </el-dropdown>
          <span>{{ username }}</span>
        </el-header>
        <el-main>
          <el-table :data="tableData" :default-sort="{ prop: 'date', order: 'descending' }">
            <el-table-column prop="projectname" label="项目名称" width="140">
            </el-table-column>
            <el-table-column prop="originator_id" label="组队发起人" width="140">
            </el-table-column>
            <el-table-column prop="team_type" label="项目类型" width="140">
            </el-table-column>
            <el-table-column prop="region" label="所在校区" width="200">
            </el-table-column>
            <el-table-column prop="details" label="项目简介" width="200">
            </el-table-column>
            <el-table-column prop="date" label="发布时间" sortable>
            </el-table-column>
            <el-table-column label="操作">
              <template slot-scope="scope">
                <el-button size="mini" @click="handleLook(scope.$index, scope.row)">查看详情</el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import global_msg from '../utils/global.js'
import { getlistInfor } from '@/api/Inforlist.js'
export default {
  name: 'InforList',
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
    additem: function () {
      this.$router.push({ path: "/users/CreatList" }); //接下来进入到CreatList
    },
    myitem: function () {
      this.$router.push({ path: "/users/MyProject" }); //接下来进入到MyProject
    },
    getlist() {
      var vm = this;//全局变量
      getlistInfor().then(function (res) {
        global_msg.requirenum = res.data.length;//改变全局requirenum
        // console.log(res);
        // console.log(res.data.length);
        // console.log(res.data[0]);
        // console.log(res.data[0].details);
        for (let item of res.data) {
          let form = {//设置添加数据的格式
            projectname: '',
            originator_id: '',
            team_type: '',
            region: '',
            details: '',
            date: '',
          }
          // console.log(item);
          form.projectname = item.requirement_name;
          form.originator_id = item.originator_id;
          form.team_type = item.team_type;
          form.details = item.details;
          form.date = item.release_time;
          form.date = form.date.replace("\"", "").replace("\"", "");//去掉时间格式的引号
          form.region = item.region;
          vm.tableData.push(form);
          // console.log(form);
          // console.log(vm.tableData);
        }
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

.el-header {
  background-color: #B3C0D1;
  color: #333;
  line-height: 60px;
}

.el-aside {
  color: #333;
}
</style>